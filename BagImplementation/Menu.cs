namespace BagImplementation {
    internal class Menu {
        Bag bag = new Bag();
        public Menu() { }

        public void Run() {
            Console.WriteLine("Your Bag of numbers is initiated");
            int n;
            do {
                PrintMenu();
                try {
                    n = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    n = -1;
                }

                switch (n) {
                    case 1: Insert(); break;
                    case 2: Remove(); break;
                    case 3: Frequency(); break;
                    case 4: Largest(); break;
                }

            } while (n != 0);

        }

        private void PrintMenu() {
            Console.WriteLine("-----------------------------------------");
            Print();
            Console.WriteLine("\ntype the program you want to use ->\n");
            Console.WriteLine("1. Insert an element ");
            Console.WriteLine("2. Remove an element ");
            Console.WriteLine("3. Check the frequency of an element ");
            Console.WriteLine("4. Check the Largest Element ");
            Console.WriteLine("0. To exit");
        }

        private void Insert() {
            Console.WriteLine("Please Type the Element you wish to insert : ");
            try {
                bag.insertElement(int.Parse(Console.ReadLine()));
            } catch (FormatException) {
                Console.WriteLine("integer expected");
            }
        }

        private void Remove() {
            Console.WriteLine("Please Type the Element you wish to remove : ");
            try {
                bag.removeElement(int.Parse(Console.ReadLine()));
            } catch (Bag.EmptyBagException) {
                Console.WriteLine("Bag is Empty");
            } catch (Bag.ItemNotFoundException) {
                Console.WriteLine("This element is not in the bag");
            } catch (FormatException) {
                Console.WriteLine("integer expected");
            }
        }
        private void Frequency() {
            Console.WriteLine("Please Type the Element you wish to know the frequency : ");

            try {
                int f = bag.frequency(int.Parse(Console.ReadLine()));
                Console.WriteLine($"The frequency of this element is : {f}");
            } catch (Bag.EmptyBagException) {
                Console.WriteLine("Bag is Empty");
            } catch (FormatException) {
                Console.WriteLine("integer expected");
            }

        }

        private void Largest() {
            try { Console.WriteLine($"The largest element in this bag is : {bag.largestElement()}"); } catch (Bag.EmptyBagException) { Console.WriteLine("Bag is Empty"); }
        }

        private void Print() {
            Console.WriteLine("The Bag Elements  : ");
            try {
                List<Tuple<int, int>> stuff = bag.printBag();
                for (int i = 0; i < stuff.Count; i++) {
                    Console.WriteLine(stuff[i]);
                }
            } catch (Bag.EmptyBagException) {
                Console.WriteLine("Bag is Empty");
            }
        }
    }
}
