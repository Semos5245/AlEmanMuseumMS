using ALEmanMuseum.Services.Common;
using System;
using Aspose.BarCode.Generation;

namespace ALEmanMuseum.Infrastructure.Barecode
{
    public class BarcodeProvider : IBarcodeProvider
    {
        public bool CreateBarcodeAndSaveTo(string content, string path)
        {
            try
            {
                new BarcodeGenerator(EncodeTypes.Code128, content)
                    .GenerateBarCodeImage().Save(path);
            }
            catch { return false; }
            return true;
        }
    }
}
