public class Differentiator {

    public static List<object> Derive(List<object> expression, string variable) {

        string word = expression[0].ToString();

        if(word == variable) {
            return new List<object> {"1"};
        }

        else {
            return new List<object> {"0"};
        }

        string op = expression[0].ToString(); // dacca e mai mult decat x sau constanta

        switch(op) {
            case "+": {
                string u = expression[1].ToString();
                string v = expression[2].ToString();

                List<object> subList = new List<object> {"+"};
                
            }
        }
    }
}