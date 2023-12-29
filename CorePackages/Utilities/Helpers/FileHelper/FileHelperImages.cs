using CorePackages.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackages.Utilities.Helpers.FileHelper;

public class FileHelperImages : IFileHelper
{
    public void Delete(string filePath)
    {
        if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
        {
            File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
        }
    }

    public string Update(IFormFile file, string filePath, string root)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
    }

    public string Upload(IFormFile file, string root)
    {
        if (file.Length > 0 || file!=null)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string filePath = GuidHelper.GuidHelper.CreateGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(root, filePath);

            using (FileStream fileStream = File.Create(fullPath))
            {
                file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                fileStream.Flush();//arabellekten siler.
                return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
            }
        }
        return null;
    }
}
//IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
//FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır