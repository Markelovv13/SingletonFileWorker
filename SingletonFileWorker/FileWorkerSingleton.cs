using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonFileWorker
{
    /// <summary>
    /// Класс для работы с текстом. Сохранение в файл только по запросу Save.
    /// До этого изменения хранятся в динамической памяти
    /// Реализация паттерна одиночка
    /// </summary>
    public sealed class FileWorkerSingleton
    {
        private static readonly Lazy<FileWorkerSingleton> instance = new Lazy<FileWorkerSingleton>(() => new FileWorkerSingleton());
        
        /// <summary>
        /// Для доступа к экземляру класса
        /// </summary>
        public static FileWorkerSingleton Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// Путь к файлу записи
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Содержимое файла в динамической памяти
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Создание экземпляра для работы с текстом
        /// Для того, чтобы у пользователя не было возможности создавать
        /// новые экземпляры класса констуктор необходимо сделать закрытым
        /// </summary> 
        private FileWorkerSingleton()
        {
            FilePath = "test2.txt";
            ReadTextFromFile();     
        }

        /// <summary>
        /// Добавить тест в файл (без сохранения в постоянную память)
        /// </summary>
        /// <param name="text"></param>
        public void WriteText(string text)
        {
            Text += text;
        }

        /// <summary>
        /// Сохранить текст в файл
        /// </summary>
        public void Save()
        {
            using (var writer = new StreamWriter(FilePath, false))
            {
                writer.WriteLine(Text);
            }
        }

        /// <summary>
        /// Прочитать данные из файла
        /// </summary>
        private void ReadTextFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Text = "";
            }
            else
            {
                using (var reader = new StreamReader(FilePath))
                {
                    Text = reader.ReadToEnd();
                }
            }
        }
    }
}
