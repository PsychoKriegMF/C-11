//Сериализация

using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace C_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument xmlDocument = new XmlDocument();

            //XmlElement root = xmlDocument.CreateElement("BookStore");
            //xmlDocument.AppendChild(root);

            //XmlElement book = xmlDocument.CreateElement("Book");
            //book.SetAttribute("ISBN", "123456");
            //root.AppendChild(book);

            //XmlElement title = xmlDocument.CreateElement("title");
            //title.InnerText = "C# Programming";
            //book.AppendChild(title);

            //xmlDocument.Save("books2.xml");

            //xmlDocument.Load("books2.xml");

            //XmlNode root = xmlDocument.DocumentElement;

            //foreach(XmlNode bookNode in root.ChildNodes)
            //{
            //    Console.WriteLine($"Book ISBN: {bookNode.Attributes["ISBN"].Value}");
            //    Console.WriteLine($"Title: {bookNode["title"].InnerText}");
            //}

            //XmlNode bookNode = xmlDocument.SelectSingleNode("/BookStore/Book[@ISBN='123456']/title");

            //if(bookNode != null )
            //{
            //    bookNode.InnerText = "Update";
            //}
            //xmlDocument.Save("books2.xml");

            string filePath = "output.txt";
            //using (FileStream fileStreamW = new FileStream(filePath,FileMode.Create, FileAccess.Write))
            //{
            //    string text = "Hello";
            //    byte[] buffer = System.Text.Encoding.ASCII.GetBytes(text);
            //    fileStreamW.Write(buffer, 0, buffer.Length);
            //}

            //using (FileStream fileStreamR = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //{               
            //    byte[] buffer = new byte[1024];
            //    int bytesRead;
            //    while((bytesRead = fileStreamR.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        string text = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
            //        Console.WriteLine(text);
            //    }
            //}

            //using (StreamWriter writer = new StreamWriter(filePath,true))
            //{
            //    writer.WriteLine("\nbajksdghjkahsd");
            //    writer.WriteLine("ajksdghjkahsd");
            //}

            //using (StreamReader reader = new StreamReader(filePath))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}

            //Console.WriteLine(File.ReadAllText(filePath));


            //var person = new { Name = "Alice", Age = 30, IsMarried = false };
            //string json = JsonConvert.SerializeObject(person);
            //Console.WriteLine(json);
            
            //var deserialised = JsonConvert.DeserializeObject<Person>(json);
            //Console.WriteLine($"Name: {deserialised.Name}, Age: {deserialised.Age}, IsMarried: {deserialised.IsMarried}");


            List<Book> books = new List<Book>();

            XDocument xmldoc = XDocument.Load("books.xml");
            foreach(var element in xmldoc.Element("books").Elements("book"))
            {
                Book book = new Book
                {
                    Title = element.Element("title").Value,
                    Author = element.Element("author").Value,
                    Year = int.Parse(element.Element("year").Value)
                };
                books.Add(book);
            }
            
            foreach(var book in books)
            {
                Console.WriteLine($"{book.Title}, {book.Author}, {book.Year}");
            }

            using (StreamReader r = new StreamReader("books.json")) 
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach(var item in array.books)
                {
                    Book book = new Book
                    {
                        Title = item.title,
                        Author = item.author,
                        Year = item.year,
                    };
                    books.Add(book);
                }
            }
            

            using (StreamReader r = new StreamReader("books.txt"))
            {
                string line;
                while((line = r.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if(parts.Length == 3)
                    {
                        Book book = new Book

                        {
                            Title = parts[0].Trim(),
                            Author = parts[1].Trim(),
                            Year = int.Parse( parts[2].Trim())
                        };
                        books.Add(book);
                    }
                }
            }
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, {book.Author}, {book.Year}");
            }


        }
    }
    public class Person
    {
        public string Name { get; set; }    
        public string Age { get; set; }
        public bool IsMarried { get; set;}

    }

}
