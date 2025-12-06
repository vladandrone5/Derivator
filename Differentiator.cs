public class Differentiator {

    public static List<object> Derive(List<object> expression, string variable) {

        if(expression.Count == 1) {
            string token = expression[0].ToString();
            if(token == variable) {
                return new List<object> {"1"};
            }

            else {
                return new List<object> {"0"};
            }

        }

        else {
        string op = expression[0].ToString(); // daca e mai mult decat x sau constanta
            switch(op) {
                case "+": {
                    var firstOperand = expression[1];
                    List<object> uList;

                    if(firstOperand is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> { firstOperand };
                    }

                    List<object> derivedU = Derive(uList, variable);

                    
                    var secondOperand = expression[2];
                    List<object> vList;

                    if(secondOperand is List<object> subList2) {
                        vList = subList2;
                    }
                    else {
                        
                        vList = new List<object> { secondOperand };
                    }

                    List<object> derivedV = Derive(vList, variable);

                    
                    List<object> res = new List<object>();
                    res.Add(expression[0]);
                    res.Add(derivedU);
                    res.Add(derivedV);

                    return res;

                }
                case "-": {

                    
                    var firstOperand = expression[1];
                    List<object> uList;

                    if(firstOperand is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> { firstOperand };
                    }

                    List<object> derivedU = Derive(uList, variable);

                    
                    var secondOperand = expression[2];
                    List<object> vList;

                    if(secondOperand is List<object> subList2) {
                        vList = subList2;
                    }
                    else {
                        
                        vList = new List<object> { secondOperand };
                    }

                    List<object> derivedV = Derive(vList, variable);

                    
                    List<object> res = new List<object>();
                    res.Add(expression[0]);
                    res.Add(derivedU);
                    res.Add(derivedV);

                    return res;
                }
                case "*": {

                    var firstOperand = expression[1];

                    List<object> uList;

                    if(firstOperand is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> {firstOperand};
                    }

                    List<object> derivedU = Derive(uList, variable); // u derivat

                    var secondOperand = expression[2];
                    List<object> vList;

                    if(secondOperand is string word2) {
                        vList = new List<object> {secondOperand};
                    }
                    else {
                        vList = (List<object>) secondOperand;
                    }

                    List<object> derivedV = Derive(vList, variable); // v derivat

                    List<object> left = new List<object> {"*"};
                    List<object> right = new List<object> {"*"};

                    left.Add(derivedU);
                    left.Add(secondOperand);

                    right.Add(firstOperand);
                    right.Add(derivedV);

                    List<object> res = new List<object> {"+"};
                    res.Add(left);
                    res.Add(right);

                    return res;
                }
                case "/": {
                    var firstOperand = expression[1];

                    List<object> uList;

                    if(firstOperand is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> {firstOperand};
                    }

                    List<object> derivedU = Derive(uList, variable); // u derivat

                    var secondOperand = expression[2];
                    List<object> vList;

                    if(secondOperand is string word2) {
                        vList = new List<object> {secondOperand};
                    }
                    else {
                        vList = (List<object>) secondOperand;
                    }

                    List<object> derivedV = Derive(vList, variable); // v derivat

                    List<object> left_left_child = new List<object> {"*"};
                    left_left_child.Add(derivedU);
                    left_left_child.Add(secondOperand);
                    
                    List<object> left_right_child = new List<object> {"*"};
                    left_right_child.Add(firstOperand);
                    left_right_child.Add(derivedV);

                    List<object> left = new List<object> {"-"};
                    left.Add(left_left_child);
                    left.Add(left_right_child);

                    List<object> right = new List<object> {"*"};
                    right.Add(secondOperand);
                    right.Add(secondOperand);

                    List<object> res = new List<object> {"/"};
                    res.Add(left);
                    res.Add(right);

                    return res;
                }
                case "sin": {

                    var u = expression[1];

                    List<object> uList;

                    if(u is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> {u};
                    }

                    List<object> derivedU = Derive(uList, variable); // u derivat

                    List<object> res = new List<object> {"*"};
                    List<object> left = new List<object> {"cos"};
                    left.Add(u);
                    res.Add(left);
                    res.Add(derivedU);

                    return res;
                    
                }
                case "cos": {
                    var u = expression[1];

                    List<object> uList;

                    if(u is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> {u};
                    }

                    List<object> derivedU = Derive(uList, variable); // u derivat

                    List<object> left = new List<object> {"-"};
                    List<object> left_in_left = new List<object> {"sin"};
                    left_in_left.Add(u);
                    left.Add(left_in_left);

                    List<object> res = new List<object> {"*"};

                    res.Add(left);
                    res.Add(derivedU);

                    return res;
                }
                case "ln": {

                    var u = expression[1];

                    List<object> uList;

                    if(u is List<object> subList) {
                        uList = subList;
                    }
                    else {
                        uList = new List<object> {u};
                    }

                    List<object> derivedU = Derive(uList, variable); // u derivat

                    List<object> res = new List<object> {"/"};
                    res.Add(derivedU);
                    res.Add(u);

                    return res;
                }
                case "^": {
                    
                    var u = expression[1];
                    string v = (string)expression[2];


                    List<object> uList;

                    if(u is string word) {
                        uList = new List<object> {u};
                    }
                    else {
                        uList = (List<object>) u;
                    }

                    List<object> derivedU = Derive(uList, variable); // u derivat

                    int exponent = 0;

                    if(int.TryParse(v, out exponent)) {
                        List<object> powerSide = new List<object> {"^", u, exponent - 1};

                        List<object> rightSide = new List<object> {"*", exponent.ToString(), powerSide};

                        List<object> res = new List<object> {"*", derivedU, rightSide};

                        return res;
                    }
                    return null;
                    
                }
                
            } 
            return null;
        }
    }
}