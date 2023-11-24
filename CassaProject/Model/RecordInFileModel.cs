using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace CassaProject.Model
{
    public class RecordInFileModel
    {
        public void LoadDataInDocument(CashOperation type, string sum, string numOfBag, string reasonOfOper)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    string filePath = dlg.FileName;

                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        string resultOfRegex = Regex.Replace(type.ToString(), @"\B(\p{Lu})", " $1").Trim();
                        string outputType = Regex.Replace(resultOfRegex, @"(?<=.)(\p{Lu})", m => m.Value.ToLower());

                        sw.WriteLine("Тип операции:\n" + outputType);

                        sw.WriteLine("Сумма:\n" + sum);
                        if (type == CashOperation.Инкассация)
                            sw.WriteLine("Номер сумки:\n" + numOfBag);
                        else if (type == CashOperation.ПеремещениеМеждуКассами)
                            sw.WriteLine("Причина операции:\n" + reasonOfOper);
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные в файл, обратитесь к разработчику", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
    }
}