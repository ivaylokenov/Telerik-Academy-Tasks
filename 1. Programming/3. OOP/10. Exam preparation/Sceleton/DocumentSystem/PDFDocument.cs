using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IDocument, IEncryptable
    {
        private int? NumberOfPages { get; set; }
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
            if (key == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
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
