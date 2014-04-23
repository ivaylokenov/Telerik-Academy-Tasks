using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class ExcelDocument : OfficeDocument, IDocument, IEncryptable
    {
        private int? Rows { get; set; }
        private int? Cols { get; set; }
        private bool isEncrypted = false;

        public bool IsEncrypted
        {
            get
            {
                return this.isEncrypted;
            }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.Rows = int.Parse(value);
            }
            else if (key == "cols")
            {
                this.Cols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        }

        public override string ToString()
        {
            if (isEncrypted)
            {

                return string.Format("{0}[encrypted]", this.GetType().Name);
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
