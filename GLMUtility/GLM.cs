using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using ComponentAce.Compression.Libs.zlib;

public class GLM
{
    private UInt32 headerAddress;
    private UInt32 nametableAddress;
    private UInt32 nametableSize;
    private UInt32 fileCount;
    private FileEntry[] fileTable;
    private string glmfilePath;
    private int chunkSize;
    private static string[] flags = { "Uncompressed", "ZLIB" };

    public GLM()
    {
        headerAddress = 0;
        nametableAddress = 0;
        nametableSize = 0;
        fileCount = 0;
        fileTable = Array.Empty<FileEntry>();
        glmfilePath = "";
        chunkSize = 1024;
    }

    public void Open(string path)
    {
        Open(path, false);
    }

    public void Open(string path, bool newfile)
	{
        glmfilePath = path;

        if (newfile)
        {
            headerAddress = 0;
            nametableAddress = 0;
            nametableSize = 0;
            fileCount = 0;
            fileTable = Array.Empty<FileEntry>();

            using (var instream = File.Open(glmfilePath, FileMode.Create)) { }
        }
        else
        {
            using (var instream = File.Open(glmfilePath, FileMode.Open))
            {
                using (var reader = new BinaryReader(instream, Encoding.ASCII, false))
                {
                    instream.Seek(-4, SeekOrigin.End);
                    headerAddress = reader.ReadUInt32();
                    instream.Seek(headerAddress, SeekOrigin.Begin);
                    var headerString = new string(reader.ReadChars(8));
                    // [0] CHNK = FourCC (chunk file)
                    // [4] B = Binary, T = Text (chunk mode)
                    // [5] B = Big Endian, L = Little Endian (byte order)
                    // [6] XX = ?
                    if (headerString != "CHNKBLXX")
                    {
                        throw new InvalidDataException("Unsupported format or missing header");
                    }
                    nametableAddress = reader.ReadUInt32();
                    nametableSize = reader.ReadUInt32();
                    fileCount = reader.ReadUInt32();
                    var oldPosition = instream.Position;

                    instream.Seek(nametableAddress, SeekOrigin.Begin);

                    string nameTable = new string(reader.ReadChars(((int)nametableSize)));
                    string[] files = nameTable.Split('\0');

                    instream.Seek(oldPosition, SeekOrigin.Begin);

                    fileTable = new FileEntry[fileCount];

                    for (int i = 0; i < fileCount; i++)
                    {
                        fileTable[i].offset = reader.ReadUInt32();
                        fileTable[i].length = reader.ReadUInt32();
                        fileTable[i].fileSize = reader.ReadUInt32();
                        fileTable[i].nametableOffset = reader.ReadUInt32();
                        fileTable[i].name = nameTable.Substring((int)fileTable[i].nametableOffset).Split('\0')[0];
                        fileTable[i].flags = reader.ReadUInt16();
                        fileTable[i].timestamp = reader.ReadUInt32();
                    }
                }
            }
        }
    }

    public FileEntry[] GetFileList()
    {
        return fileTable;
    }

    public string GetPath()
    {
        return glmfilePath;
    }

    public string GetFlagName(int flag)
    {
        if(flag > (flags.Length - 1) || flag < 0)
        {
            return "Unknown";
        }

        return flags[flag];
    }

    public void Extract(int index, string directory)
    {
        if (fileTable.Length == 0)
            return;

        string path = directory.TrimEnd('\\') + "\\" + fileTable[index].name;

        using (var instream = File.Open(glmfilePath, FileMode.Open))
        {
            using (var outstream = File.Open(path, FileMode.Create))
            {
                instream.Seek(fileTable[index].offset, SeekOrigin.Begin);

                byte[] buffer = new byte[chunkSize];
                int bytestoRead = (int)fileTable[index].length;

                if (fileTable[index].flags == 1)
                {
                    var decompressor = new ZOutputStream(outstream);

                    while (bytestoRead > 0)
                    {
                        int readCount = instream.Read(buffer, 0, chunkSize);

                        if (readCount == 0)
                        {
                            throw new EndOfStreamException("Unexpected end of file reached");
                        }

                        if (bytestoRead >= chunkSize)
                        {
                            decompressor.Write(buffer, 0, chunkSize);
                        }
                        else
                        {
                            decompressor.Write(buffer, 0, bytestoRead);
                        }

                        bytestoRead -= readCount;
                    }
                    decompressor.Flush();
                }
                else
                {
                    while (bytestoRead > 0)
                    {
                        int readCount = instream.Read(buffer, 0, chunkSize);

                        if (readCount == 0)
                        {
                            throw new EndOfStreamException("Unexpected end of file reached");
                        }

                        if (bytestoRead >= chunkSize)
                        {
                            outstream.Write(buffer, 0, chunkSize);
                        }
                        else
                        {
                            outstream.Write(buffer, 0, bytestoRead);
                        }

                        bytestoRead -= readCount;
                    }
                }
            }

            if (File.Exists(path))
            {
                DateTimeOffset timestamp = DateTimeOffset.FromUnixTimeSeconds((long)fileTable[index].timestamp);
                File.SetLastWriteTime(path, timestamp.DateTime);
            }
        }
    }

    public void Delete(int[] deleteIndex)
    {
        var tempFile = Path.GetTempFileName();
        FileEntry[] newfileTable = new FileEntry[fileTable.Length - deleteIndex.Length];

        using (var outstream = File.Open(tempFile, FileMode.Create))
        {
            int newIndex = 0;
            StringBuilder sb = new StringBuilder();

            using (var instream = File.Open(glmfilePath, FileMode.Open))
            {
                for (int i = 0; i < fileTable.Length; i++)
                {
                    if (deleteIndex.Contains(i))
                    {
                        continue;
                    }

                    instream.Seek(fileTable[i].offset, SeekOrigin.Begin);

                    newfileTable[newIndex].name = fileTable[i].name;
                    newfileTable[newIndex].offset = (UInt32)outstream.Position;
                    newfileTable[newIndex].length = fileTable[i].length;
                    newfileTable[newIndex].fileSize = fileTable[i].fileSize;
                    newfileTable[newIndex].nametableOffset = (UInt32)sb.Length;
                    newfileTable[newIndex].flags = fileTable[i].flags;
                    newfileTable[newIndex].timestamp = fileTable[i].timestamp;

                    sb.Append(newfileTable[newIndex].name + '\0');

                    byte[] buffer = new byte[chunkSize];
                    int bytestoRead = (int)fileTable[i].length;
                    while (bytestoRead > 0)
                    {
                        int readCount = instream.Read(buffer, 0, chunkSize);

                        if (readCount == 0)
                        {
                            throw new EndOfStreamException("Unexpected end of file reached");
                        }

                        outstream.Write(buffer, 0, chunkSize);

                        bytestoRead -= readCount;
                    }

                    newIndex++;
                }
            }

            nametableAddress = (UInt32)outstream.Position;
            outstream.Write(Encoding.ASCII.GetBytes(sb.ToString()), 0, sb.Length);
            headerAddress = (UInt32)outstream.Position;
            outstream.Write(Encoding.ASCII.GetBytes("CHNKBLXX"), 0, 8);
            outstream.Write(BitConverter.GetBytes(nametableAddress), 0, 4);
            nametableSize = (UInt32)sb.Length;
            outstream.Write(BitConverter.GetBytes(nametableSize), 0, 4);
            fileCount = (UInt32)newfileTable.Length;
            outstream.Write(BitConverter.GetBytes(fileCount), 0, 4);

            for (int i = 0; i < newfileTable.Length; i++)
            {
                outstream.Write(BitConverter.GetBytes(newfileTable[i].offset), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].length), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].fileSize), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].nametableOffset), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].flags), 0, 2);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].timestamp), 0, 4);
            }

            outstream.Write(new byte[] { 0, 0, 0, 0 }, 0, 4);
            outstream.Write(BitConverter.GetBytes(headerAddress), 0, 4);
        }

        fileTable = newfileTable;

        File.Delete(glmfilePath);
        File.Move(tempFile, glmfilePath);
    }

    public void Add(string[] filepaths, int flag)
    {
        var tempFile = Path.GetTempFileName();

        List<int> skipList = new List<int>();
        for (int i = 0; i < fileTable.Length; i++)
        {
            for (int u = 0; u < filepaths.Length; u++)
            {
                if (fileTable[i].name == Path.GetFileName(filepaths[u]))
                {
                    skipList.Add(i);
                }
            }
        }

        FileEntry[] newfileTable = new FileEntry[fileTable.Length + (filepaths.Length - skipList.Count)];

        using (var outstream = File.Open(tempFile, FileMode.Create))
        {
            int newIndex = 0;
            StringBuilder sb = new StringBuilder();

            using (var instream = File.Open(glmfilePath, FileMode.Open))
            {
                for (int i = 0; i < fileTable.Length; i++)
                {
                    if (skipList.Contains(i))
                    {
                        continue;
                    }

                    instream.Seek(fileTable[i].offset, SeekOrigin.Begin);

                    newfileTable[newIndex].name = fileTable[i].name;
                    newfileTable[newIndex].offset = (UInt32)outstream.Position;
                    newfileTable[newIndex].length = fileTable[i].length;
                    newfileTable[newIndex].fileSize = fileTable[i].fileSize;
                    newfileTable[newIndex].nametableOffset = (UInt32)sb.Length;
                    newfileTable[newIndex].flags = fileTable[i].flags;
                    newfileTable[newIndex].timestamp = fileTable[i].timestamp;

                    sb.Append(newfileTable[newIndex].name + '\0');

                    byte[] buffer = new byte[chunkSize];
                    int bytestoRead = (int)fileTable[i].length;
                    while (bytestoRead > 0)
                    {
                        int readCount = instream.Read(buffer, 0, chunkSize);

                        if (readCount == 0)
                        {
                            throw new EndOfStreamException("Unexpected end of file reached");
                        }

                        outstream.Write(buffer, 0, chunkSize);

                        bytestoRead -= readCount;
                    }

                    newIndex++;
                }
            }

            for (int i = 0; i < filepaths.Length; i++)
            {
                Debug.WriteLine("Files: " + filepaths.Length);
                Debug.WriteLine("Adding: " + filepaths[i] + ", " + flag);

                if (flag == 1)
                {
                    using (var instream = File.Open(filepaths[i], FileMode.Open))
                    {
                        newfileTable[newIndex].name = Path.GetFileName(filepaths[i]);
                        newfileTable[newIndex].offset = (UInt32)outstream.Position;
                        newfileTable[newIndex].fileSize = (UInt32)instream.Length;
                        newfileTable[newIndex].nametableOffset = (UInt32)sb.Length;
                        newfileTable[newIndex].flags = (UInt16)flag;
                        newfileTable[newIndex].timestamp = (UInt32)new DateTimeOffset(File.GetLastWriteTime(filepaths[i])).ToUnixTimeSeconds();

                        sb.Append(newfileTable[newIndex].name + '\0');

                        var compressor = new ZOutputStream(outstream, zlibConst.Z_BEST_SPEED);
                        int bytestoRead = (int)instream.Length;
                        while (bytestoRead > 0)
                        {
                            byte[] buffer = new byte[chunkSize];

                            int readCount = instream.Read(buffer, 0, chunkSize);

                            if (readCount == 0)
                            {
                                throw new EndOfStreamException("Unexpected end of file reached");
                            }

                            compressor.Write(buffer, 0, readCount);

                            bytestoRead -= readCount;
                        }

                        compressor.finish();
                        long compressedSize = outstream.Position - newfileTable[newIndex].offset;
                        newfileTable[newIndex].length = (UInt32)compressedSize;
                        int padding = (int)compressedSize;
                        while (padding > 0)
                        {
                            padding -= chunkSize;
                        }
                        for (int p = 0; p < Math.Abs(padding); p++)
                        {
                            outstream.WriteByte(0);
                        }
                    }
                }
                else
                {
                    using (var instream = File.Open(filepaths[i], FileMode.Open))
                    {
                        newfileTable[newIndex].name = Path.GetFileName(filepaths[i]);
                        newfileTable[newIndex].offset = (UInt32)outstream.Position;
                        newfileTable[newIndex].length = (UInt32)instream.Length;
                        newfileTable[newIndex].fileSize = (UInt32)instream.Length;
                        newfileTable[newIndex].nametableOffset = (UInt32)sb.Length;
                        newfileTable[newIndex].flags = (UInt16)flag;
                        newfileTable[newIndex].timestamp = (UInt32)new DateTimeOffset(File.GetLastWriteTime(filepaths[i])).ToUnixTimeSeconds();

                        sb.Append(newfileTable[newIndex].name + '\0');

                        int bytestoRead = (int)instream.Length;
                        while (bytestoRead > 0)
                        {
                            byte[] buffer = new byte[chunkSize];

                            int readCount = instream.Read(buffer, 0, chunkSize);

                            if (readCount == 0)
                            {
                                throw new EndOfStreamException("Unexpected end of file reached");
                            }

                            outstream.Write(buffer, 0, chunkSize);

                            bytestoRead -= readCount;
                        }
                    }
                }

                newIndex++;
            }

            nametableAddress = (UInt32)outstream.Position;
            outstream.Write(Encoding.ASCII.GetBytes(sb.ToString()), 0, sb.Length);
            headerAddress = (UInt32)outstream.Position;
            outstream.Write(Encoding.ASCII.GetBytes("CHNKBLXX"), 0, 8);
            outstream.Write(BitConverter.GetBytes(nametableAddress), 0, 4);
            nametableSize = (UInt32)sb.Length;
            outstream.Write(BitConverter.GetBytes(nametableSize), 0, 4);
            fileCount = (UInt32)newfileTable.Length;
            outstream.Write(BitConverter.GetBytes(fileCount), 0, 4);

            Array.Sort(newfileTable, (x, y) => string.Compare(x.name, y.name));

            for (int i = 0; i < newfileTable.Length; i++)
            {
                outstream.Write(BitConverter.GetBytes(newfileTable[i].offset), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].length), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].fileSize), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].nametableOffset), 0, 4);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].flags), 0, 2);
                outstream.Write(BitConverter.GetBytes(newfileTable[i].timestamp), 0, 4);
            }

            outstream.Write(new byte[] { 0, 0, 0, 0 }, 0, 4);
            outstream.Write(BitConverter.GetBytes(headerAddress), 0, 4);
        }

        fileTable = newfileTable;

        File.Delete(glmfilePath);
        File.Move(tempFile, glmfilePath);
    }
}
