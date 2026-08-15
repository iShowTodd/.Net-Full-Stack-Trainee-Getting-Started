namespace HashSetAndSortedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
             new Customer { Name = "Issam A", Telephone = "+1 123 123 4565" },
             new Customer { Name = "Reem S", Telephone = "+1 123 123 4566" },
             new Customer { Name = "Issam B", Telephone = "+1 123 123 4567" },
             new Customer { Name = "Abeer A", Telephone = "+1 123 123 4568" },
             new Customer { Name = "Salem D", Telephone = "+1 123 123 4569" }
            };

            Console.WriteLine("Hashset");
            Console.WriteLine("-------");

            var custHashSet = new HashSet<Customer>(customers);

            var customers2 = new List<Customer>
            {
             new Customer { Name = "Essam A", Telephone = "+1 123 123 4533" },
             new Customer { Name = "Rim S", Telephone = "+1 123 123 4554" }
            };

            var custHashSet2 = new HashSet<Customer>(customers2);

            custHashSet.UnionWith(custHashSet2);

            var customerSortedSet = new SortedSet<Customer>(customers);
            customerSortedSet.Add(new Customer { Name = "Baker S", Telephone = "+1 123 123 3354" });
            foreach (var item in customerSortedSet) Console.WriteLine(item);
        }
    }

    internal class Customer : IComparable<Customer>
    {
        public string Name { get; set; }

        public string Telephone
        {
            get; set;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = (hash * 397) + Telephone.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;

            if (customer is null)
                return false;

            return this.Telephone.Equals(customer.Telephone);
        }

        public override string ToString()
        {
            return $"{Name} ({Telephone})";
        }

        // Here means you are sorting by name
        //"How do I compare myself to another object?"

        /*

         IEnumerable<T>          →  "I can give you an enumerator"
             └── GetEnumerator() →  returns an IEnumerator<T>

        IEnumerator<T>          →  "I know how to walk through elements one by one"
            ├── MoveNext()      →  advance and return true/false
            ├── Current         →  the element at current position
            └── Reset()         →  go back to start

        IComparable<T>          →  completely separate concern
            └── CompareTo()     →  "how do I rank against another instance?"
                                    used by Sort(), SortedSet<T>, SortedList<T>
         */

        public int CompareTo(Customer? other)
        {
            if (object.ReferenceEquals(this, other))
                return 0;

            if (other is null)
                return -1;

            return this.Name.CompareTo(other.Name);
        }
    }
}