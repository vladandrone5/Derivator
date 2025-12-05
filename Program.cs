using System;


class Program {

    static void PrintTree(List<object> node) {
        
        Console.Write("[");

        for(int i = 0; i < node.Count; i++) {
            
            var item = node[i];

            if(item is string word) {
                Console.Write($"'{word}'");
            }
            else if(item is List<object> subList) {
                PrintTree(subList);
            }

            if(i != node.Count - 1) {
                Console.Write(", ");
            }
        }

        Console.Write("]");
    }

    static void Main() {
        List<object> list = new List<object> {"sin"};
        list.Add(new List<object> {"sin", "x"});
        PrintTree(list);
        Console.WriteLine();
    }
}