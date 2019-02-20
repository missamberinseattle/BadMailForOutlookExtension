using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMailForOutlook
{
    public class NameList
    {
        #region Constructors, Destructors, and Initializers
        private NameList(string namePath)
        {
            _names = File.ReadAllLines(namePath);
        }
        #endregion

        #region Private Data Members
        private string[] _names;
        #endregion

        #region Private Static Members
        private static NameList _instance;
        #endregion

        #region Public Methods
        public bool HasName(string name)
        {
            return _names.Contains(name.ToUpper());
        }

        public int NameIndex(string name)
        {
            var done = false;
            var start = 0;
            var end = _names.Length - 1;
            var middle = end / 2;
            var searchDepth = 0;

            name = name.ToUpper();

            while (!done)
            {
                var compare = name.CompareTo(_names[middle]);
                searchDepth++;
                if (compare == 0)
                {
                    // Found it!
                    Trace.WriteLine("Search depth for " + name + " == " + searchDepth);
                    return middle;
                }

                if (compare == -1)
                {
                    // Before the middle value
                    end = middle;
                    middle = (end - start) / 2;
                    middle += start;
                }
                else if (compare == 1)
                {
                    // After the middle value
                    start = middle;
                    middle = ((int)(Math.Ceiling((double)(end - start) / 2.0))) + start;
                    
                }

                if (end <= start || middle < start)
                {
                    done = true;
                }
            }

            Trace.WriteLine("'" + name + "' not found!  Searched " + searchDepth + " level(s)");
            return -1;
        }
        #endregion

        #region Public Static Methods
        public static NameList GetInstance(string filePath = null)
        {
            if (_instance == null && filePath == null)
            {
                throw new ArgumentNullException("filePath", "Can't create instance with null file path");
            }
            else if (_instance == null)
            {
                _instance = new NameList(filePath);
            }

            return _instance;
        }
        #endregion
    }
}
