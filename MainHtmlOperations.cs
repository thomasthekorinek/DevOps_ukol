using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevOps
{

    internal class MainHtmlOperations
    {
        public List<string> GetNamesRaw(string htmlCode)
        {
            string htmlCodeInner = htmlCode;
            List<string> listName = new List<string>();


            Regex filterName = new Regex(@"<h3 class=""card-title mb-0"">\n[ a-žA-Ž()\/.]*\n[ ]*<\/h3>");
            

            while (true)
            {
                var matchName = filterName.Match(htmlCodeInner);

                if (matchName.Success)
                {
                    listName.Add(matchName.Value);
                    htmlCodeInner = htmlCodeInner.Replace(matchName.Value, "");
                }
                else
                    break;

            }

            return listName;
        }
        public List<string> GetAddressesRaw(string htmlCode)
        {
            string htmlCodeInner = htmlCode;
            List<string> listAddress = new List<string>();

            Regex filterAddress = new Regex(@"<a class=""card card-lg card-link-bottom"" href=""[\/\w -]*"">");


            while (true)
            {
                var matchAddress = filterAddress.Match(htmlCodeInner);

                if (matchAddress.Success)
                {
                    listAddress.Add(matchAddress.Value);
                    htmlCodeInner = htmlCodeInner.Replace(matchAddress.Value, "");
                }
                else
                    break;

            }

            return listAddress;
        }
        public List<string> GetNames(string htmlCode)
        {
            List<string> listNames = GetNamesRaw(htmlCode);
            List<string> listNamesFinal = new List<string>();

            Regex filterName = new Regex(@"\n[ a-žA-Ž()\/.]*\n[ ]*");

            foreach (string item in listNames)
            {
                var matchName = filterName.Match(item);

                if (matchName.Success)
                {
                    listNamesFinal.Add(matchName.Value.Trim());
                }
                else
                    continue;
            }
            return listNamesFinal;
            //listNamesFinal.ForEach(i => Console.Write("{0}\t", i));
        }
        public List<string> GetAddress(string htmlCode)
        {
            List<string> listAddresses = GetAddressesRaw(htmlCode);
            List<string> listAddressesFinal = new List<string>();

            Regex filterAddress = new Regex(@"\/kariera\/[-a-ž]*\/");

            foreach (string item in listAddresses)
            {
                var matchAddress = filterAddress.Match(item);

                if (matchAddress.Success)
                {
                    listAddressesFinal.Add(matchAddress.Value.Trim());
                }
                else
                    continue;
            }
            return listAddressesFinal;
            //listAddressesFinal.ForEach(i => Console.Write("{0}\t", i));
        }
    }
    
}