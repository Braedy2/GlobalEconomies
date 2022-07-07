using System.Xml;

//edited by maximus

namespace GlobalEconomies {
    public class Program {
        const string XmlFile = "global_economies.xml";
        static int startYear = 2017;
        static int endYear = 2021;
        static void Main(string[] args) {
            //reading file
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFile);

            XmlNode rootNode = doc.ChildNodes[2];

            XmlNodeList regionList = rootNode.ChildNodes;


            Console.WriteLine("Welcome to Braedan Watson's World Economies Data Reporter");
            Console.WriteLine("=========================================================");
            char menuSelection = 'x';
            do {
                printMenu();
                menuSelection = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (menuSelection) {
                    case 'y':
                        //year adjustment
                        adjustYears();
                        break;
                    case 'r':
                        //regional print
                        selectRegion(regionList);
                        break;
                    case 'm':
                        //specific metric for everywhere
                        break;
                    case 'x':
                        break;
                    default:
                        Console.WriteLine("\n\nERROR: Incorrect Input, Try Again");
                        break;
                }
            } while (menuSelection != 'x');
        }
        private static void printMenu() {
            Console.Write($"'Y' to adjust the range of years (currently {startYear} to {endYear})\n" +
                "'R' to print a regional summary\n" +
                "'M' to print a specific metric for all regions\n" +
                "'X' to exit the program\n" +
                "Your selection: ");
        }
        private static void adjustYears() {
            bool validYears = true;
            do {
                if (!validYears)
                    Console.WriteLine("ERROR: Choose years carefully");

                Console.Write("Starting Year (1970 to 2021): ");
                startYear = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                if (startYear < 1970 || startYear > 2021) {
                    validYears = false;
                    continue;
                }

                if (startYear < 2016)
                    Console.Write($"Ending Year ({startYear} to {startYear + 5}): ");
                else
                    Console.Write($"Ending Year ({startYear} to 2021): ");
                endYear = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                if (endYear < startYear || endYear > startYear + 5) {
                    validYears = false;
                    continue;
                }
                validYears = true;
            } while (!validYears);
        }
        private static void selectRegion(XmlNodeList regionList) {
            int selection = 0;
            Console.WriteLine("Select a Region by Number as Shown Below . . .\n");
            for (int i = 1; i < regionList.Count; i++) {
                if (i.ToString().Length == 1)
                    Console.Write("  ");
                else if (i.ToString().Length == 2)
                    Console.Write(" ");
                Console.WriteLine(i + ". " + regionList[i].OuterXml.Substring(regionList[i].OuterXml.IndexOf("rname") + 7, regionList[i].OuterXml.IndexOf("><year yid") - 26));
            }
            Console.WriteLine();
            Console.Write("Enter a Region #: ");
            selection = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            displayRegionInformation(regionList[selection]);
        }
        private static void displayRegionInformation(XmlNode element) {
            Console.WriteLine($"Economic Information for {element.Attributes.GetNamedItem("rname").Value}\n" + /*OuterXml.Substring(element.OuterXml.IndexOf("rname") + 7, element.OuterXml.IndexOf("><year yid") - 26)}\n" +*/
                $"----------------------------------------------\n\n" +
                $"");

            int numYears = endYear - startYear;
            double[] inflationCPI = new double[numYears];
            double[] inflationGDP = new double[numYears];
            double[] realInterest = new double[numYears];
            double[] lendingInterest = new double[numYears];
            double[] depositInterest = new double[numYears];
            double[] unemploymentNTL = new double[numYears];
            double[] unemploymentIPO = new double[numYears];
            for (int i = 0; i < numYears; i++) {
                //element.ChildNodes[startYear - 1970 + i].OuterXml.Substring(element.ChildNodes[startYear - 1970 + i].OuterXml.IndexOf("consumer_prices_percent") + 25, element.ChildNodes[startYear - 1970 + i].OuterXml.IndexOf(""))
                //inflationCPI[i] = element.Attributes.GetNamedItem("year");
                //    inflationGDP[i] =
                //    realInterest[i] =
                //    lendingInterest[i] =
                //    depositInterest[i] =
                //    unemploymentNTL[i] =
                //    unemploymentIPO[i] =
            }



        }
    }
}