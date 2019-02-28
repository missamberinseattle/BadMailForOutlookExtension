using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BadMailForOutlook
{
    public class PatternCollection : List<Pattern>
    {
        public PatternCollection() : base()
        {
            Init(null);
        }

        public PatternCollection(string filePath) : base()
        {
            Init(filePath);
        }

        private void Init(string filePath)
        {
            LastModified = DateTime.MinValue;
            AutoSort = true;

            if (filePath != null)
            {
                FilePath = Path.GetFullPath(filePath);
                Load();
            }
        }

        private static Dictionary<string, PatternCollection> 
            _collectionDictionary = new Dictionary<string, PatternCollection>();
        private bool _isDirty;

        public string FilePath { get; set; }
        public DateTime LastModified { get; private set; }
        public bool AutoSort { get; set; }

        public new void Add(Pattern item)
        {
            base.Add(item);
            Sort();
            _isDirty = true;
        }

        public new void AddRange(IEnumerable<Pattern> collection)
        {
            base.AddRange(collection);
            Sort();
            _isDirty = true;
        }

        public new void Remove(Pattern item)
        {
            base.Remove(item);
            _isDirty = true;
        }

        public new int RemoveAll(Predicate<Pattern> match)
        {
            var result = base.RemoveAll(match);
            _isDirty = true;
            return result;
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            _isDirty = true;
        }

        public new void RemoveRange(int index, int count)
        {
            base.RemoveRange(index, count);
            _isDirty = true;
        }

        public new void Sort()
        {
            if (AutoSort)
            {
                base.Sort();
            }
        }

        public new bool Contains(Pattern pattern)
        {
            if (Count == 0) return false;

            var result = (from t in this
                            where t.Expression == pattern.Expression
                            select t).Any();
            return result;
        }

        public void MarkDirty()
        {
            _isDirty = true;
        }

        public void Save()
        {
            if (!_isDirty) return;

            var output = new StringBuilder();

            for(var xx = 0; xx < Count; xx++)
            {
                output.AppendLine(this[xx].FormatForFile());
            }

            File.WriteAllText(FilePath, output.ToString());

            UpdateFileTime();
            _isDirty = false;
        }
        public void Load()
        {
            if (FilePath == null)
            {
                throw new ArgumentException("FilePath is null, cannot load");
            }

            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("Could not find pattern file", FilePath);
            }

            if (Count > 0)
            {
                Clear();
            }

            var fileInfo = new FileInfo(FilePath);

            var oldAutoSort = AutoSort;
            AutoSort = false;

            var lines = File.ReadAllLines(FilePath);

            for (var xx = 0; xx < lines.Length; xx++)
            {
                Add(Pattern.FromRegEx(lines[xx]));
            }

            UpdateFileTime();

            AutoSort = oldAutoSort;
            Sort();
            _isDirty = false;
        }

        private void UpdateFileTime()
        {
            var fileInfo = new FileInfo(FilePath);
            LastModified = fileInfo.LastAccessTime;
        }

        public static PatternCollection GetCollection(string filePath)
        {
            PatternCollection collection = null;

            if (_collectionDictionary.ContainsKey(filePath))
            {
                collection = _collectionDictionary[filePath];
            }
            else
            {
                collection = new PatternCollection(filePath);
                _collectionDictionary.Add(filePath, collection);
            }

            var fileInfo = new FileInfo(collection.FilePath);

            if (fileInfo.LastWriteTime > collection.LastModified)
            {
                collection.Load();
            }

            return collection;
        }

        public Pattern Find(string expression)
        {
            var pattern = (from p in this
                           where p.Expression == expression
                           select p).FirstOrDefault();

            return pattern;
        }
    }
}
