namespace BagImplementation {
    public class Bag {

        public class EmptyBagException : Exception { };
        public class ItemNotFoundException : Exception { };

        private List<Tuple<int, int>> stuff;

        public Bag() {
            stuff = new List<Tuple<int, int>>();
        }


        private int searchBag(int e) {
            int counter = 0;
            int searched = -1;
            while (counter < stuff.Count) {
                if (stuff[counter].Item1 == e) {
                    searched = counter;
                    break;
                }
                counter++;
            }
            return searched;

        }
        public void insertElement(int e) {
            int searched = searchBag(e);
            if (searched == -1) { stuff.Add(new Tuple<int, int>(e, 1)); } else {
                stuff[searched] = new Tuple<int, int>(e, stuff[searched].Item2 + 1);
            }
        }

        public void removeElement(int e) {
            if (stuff.Count == 0) { throw new EmptyBagException(); }

            int searched = searchBag(e);
            if (searched == -1) { throw new ItemNotFoundException(); } else {
                if (stuff[searched].Item2 == 1) {
                    stuff.RemoveAt(searched);
                } else {
                    stuff[searched] = new Tuple<int, int>(e, stuff[searched].Item2 - 1);
                }
            }
        }

        public int frequency(int e) {
            if (stuff.Count == 0) { throw new EmptyBagException(); }
            int f = 0;
            int searched = searchBag(e);
            if (searched == -1) { f = 0; } else { f = stuff[searched].Item2; }
            return f;
        }

        public int largestElement() {
            if (stuff.Count == 0) { throw new EmptyBagException(); }

            int largest = stuff[0].Item1;
            int max = stuff[0].Item2;
            for (int i = 0; i < stuff.Count; i++) {
                if (stuff[i].Item2 > max) {
                    max = stuff[i].Item2;
                    largest = stuff[i].Item1;
                }
            }
            return largest;
        }

        public List<Tuple<int, int>> printBag() {
            if (stuff.Count == 0) { throw new EmptyBagException(); }
            return stuff;

        }

    }
}
