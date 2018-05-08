using SPK.DocumentCenterLibs.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SPK.DocumentCenterLibs.Controllers
{
    public class RefDocController : IDocumentControl
    {
        public event EventHandler<CsvWrittenEventArgs> CsvWriting;

        public event EventHandler<CsvCreatedEventArgs> CsvBeginCreate;

        public event EventHandler<CsvCreatedEventArgs> CsvCreateCompleted;

        public void ExportCSV(string output, List<RefDoc> items)
        {
            if (items.Count == 0) return;
            if (File.Exists(output)) File.Delete(output);

            CsvCreatedEventArgs csvCreatedArgs = new CsvCreatedEventArgs();
            var fileInfo = new FileInfo(output);

            using (StreamWriter sw = new StreamWriter(new FileStream(output, FileMode.Append)))
            {
                csvCreatedArgs.FileCreated = fileInfo;
                csvCreatedArgs.IsCompleted = false;
                OnCsvBeginCreate(csvCreatedArgs);

                sw.WriteLine(items[0].CSVHead());

                for (int i = 0; i < items.Count; i++)
                {
                    var message = items[i].CSVLine();
                    sw.WriteLine(message);

                    CsvWrittenEventArgs args = new CsvWrittenEventArgs();
                    args.Message = message;
                    OnCsvWritting(args);
                }
            }

            csvCreatedArgs.IsCompleted = true;
            OnCsvCreateCompleted(csvCreatedArgs);
        }

        protected virtual void OnCsvWritting(CsvWrittenEventArgs e)
        {
            EventHandler<CsvWrittenEventArgs> handler = CsvWriting;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnCsvBeginCreate(CsvCreatedEventArgs e)
        {
            EventHandler<CsvCreatedEventArgs> handler = CsvBeginCreate;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnCsvCreateCompleted(CsvCreatedEventArgs e)
        {
            EventHandler<CsvCreatedEventArgs> handler = CsvCreateCompleted;
            if (handler != null) handler(this, e);
        }
    }

    public class CsvWrittenEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class CsvCreatedEventArgs : EventArgs
    {
        public FileInfo FileCreated { get; set; }
        public bool IsCompleted { get; set; }
    }
}