using System.Net;

namespace DevOps
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
                {
                DownloadPage dp = new DownloadPage();
                MainHtmlOperations mho = new MainHtmlOperations();
                GetInfoHtmlOperations giho = new GetInfoHtmlOperations();
                FileMaker fm = new FileMaker();

                List<string> listNames = new List<string>();
                List<string> listAddress = new List<string>();
                List<string> listInfos = new List<string>();

                listNames = mho.GetNames(await dp.GetHtml("/kariera/"));
                listAddress = mho.GetAddress(await dp.GetHtml("/kariera/"));

                foreach(string item in listAddress)
                {
                    listInfos.Add(giho.ExtractText(giho.GetInfoRaw(await dp.GetHtml(item))));
                }
                for(int i = 0; i < listNames.Count; i++)
                {
                    fm.CreateFile(listNames[i],listInfos[i]);
                }
                }
            catch (Exception)
            {
                Console.WriteLine("Nastala CHYBA!");
            }
            
        }
    }
}