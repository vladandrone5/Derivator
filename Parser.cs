public class Parser {

    public static List<object> Parse(string input) {
        string newInput = input.Trim();

        int index = 0;

        return ParseRecursive(newInput, ref index);
    }

    private static List<object> ParseRecursive(string input, ref int index) {
        
        List<object> currentList = new List<object>();

        while(index < input.Length) {

            if(input[index] == ' ' || input[index] == ',') {
                index++;
                continue;
            }

            if(input[index] == ']') {
                index++;
                return currentList;
            }

            if(input[index] == '[') {
                index++;

                List<object> subList = ParseRecursive(input, ref index);
                currentList.Add(subList);
            }

            else {
                int start = index;

                while(index < input.Length && input[index] == ' ' && input[index] != ',' && input[index] != ']') {
                    index++;
                }
                
                int len = index - start;
                string word = input.Substring(start, len);
                currentList.Add(word);
            }

        }

        return currentList;
    }

    
    
}