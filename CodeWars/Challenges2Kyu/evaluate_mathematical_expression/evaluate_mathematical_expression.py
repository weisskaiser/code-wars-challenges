def calc(expression: str):
    return eval_postfix(to_postfix(expression.replace(' ','')))

def to_postfix(expr: str) -> str:
    output = ""
    operations = []
    precedence_by_operator = {
        "+":1,
        "-":1,
        "/":2,
        "*":2,
        "!":3,
    }

    lst_c = None
    for c in expr:

        if c.isdigit():
            output += c
        elif c in precedence_by_operator:
            if c == '-' and (lst_c == None or lst_c == '(' or lst_c in precedence_by_operator):
                c = '!'
            
            while operations and operations[-1] != '(' and precedence_by_operator[operations[-1]] >= precedence_by_operator[c]:
                if output and output[-1] != ' ': output += ' '
                output += operations.pop()

            if output and output[-1] != ' ': output += ' '
            operations.append(c)
        elif c == '(':
            operations.append(c)
        elif c == ')':
            while operations[-1] != '(':
                output += f" {operations.pop()}"
            operations.pop()

        lst_c = c
    
    while operations:
        output += f" {operations.pop()}"

    return output

def eval_postfix(post_fix: str) -> float:
    eval_stack = []

    for token in post_fix.split(' '):
        if token.isdigit():
            eval_stack.append(float(token))
        else:
            if token == '!':
                n = eval_stack.pop()
                eval_stack.append(-n)
            else:
                n2 = eval_stack.pop()
                n1 = eval_stack.pop()

                if token == '/':
                    eval_stack.append(n1/n2)
                elif token == '+':
                    eval_stack.append(n1+n2)
                elif token == '-':
                    eval_stack.append(n1-n2)
                elif token == '*':
                    eval_stack.append(n1*n2)
    return eval_stack[0]