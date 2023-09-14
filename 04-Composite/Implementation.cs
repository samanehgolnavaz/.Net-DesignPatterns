using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    /// <summary>
    /// Component
    /// </summary>
    public abstract class FileSystemTeam
    {
        public string Name { get; set; }
        public abstract long GetSize();
        public FileSystemTeam(string name, long size)
        {
            Name = name;
        }

        protected FileSystemTeam(string name)
        {
            Name = name;
        }
    }
    /// <summary>
    /// Leaf
    /// </summary>
    public class File:FileSystemTeam
    {
        private long _size;
        public File(string name,long size):base(name) 
        {
            _size = size;
        }
        public override long GetSize()
        {
            return _size;
        }
    }
    /// <summary>
    /// Composite
    /// </summary>
    public class Directory : FileSystemTeam
    {
        private List<FileSystemTeam> _fileStstemteams=new List<FileSystemTeam>();
        private long _size;
        public Directory(string name, long size) : base(name)
        {
            _size = size;
        }
        public void Add(FileSystemTeam itemToAdd)
        {
            _fileStstemteams.Add(itemToAdd);    
        }
        public void Remove(FileSystemTeam itemToRemove)
        {
            _fileStstemteams.Remove(itemToRemove);
        }
        public override long GetSize()
        {
            var treeSize = _size;
            foreach (var fileSystemItem in _fileStstemteams)
            {
                treeSize += fileSystemItem.GetSize();
            }
            return treeSize;
        }
    }
}
