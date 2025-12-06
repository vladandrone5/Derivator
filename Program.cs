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
                if(subList.Count == 1 && subList[0] is string token) {
                    Console.Write($"'{token}'");
                }
                else {
                    PrintTree(subList);
                }
            }
            else {
                Console.Write(item.ToString());
            }

            if(i != node.Count - 1) {
                Console.Write(", ");
            }
        }

        Console.Write("]");
    }

    static void Main() {
        Console.WriteLine("Enter a prefix expression:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter the variable to derive by");
        string variable = Console.ReadLine();

        List<object> expression = Parser.Parse(input);

        List<object> derivative = Differentiator.Derive(expression, variable);

        Console.WriteLine("The result is:");
        PrintTree(derivative);
    }
}