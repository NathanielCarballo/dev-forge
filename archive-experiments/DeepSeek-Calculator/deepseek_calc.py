import tkinter as tk
from tkinter import messagebox

class Calculator(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Calculator")
        self.geometry("600x400")
        self.history = []

        #create display
        self.display = tk.Entry(self, font=('Arial', 18), justify='right')
        self.display.grid(row=0, column=0, columnspan=4, sticky='nsew', padx=10, pady=10)
        self.display.bind('<Key>', self.on_key_press)

        #create buttons grid
        buttons = [
            ('7', 1, 0), ('8', 1, 1), ('9', 1, 2), ('/', 1, 3),
            ('4', 2, 0), ('5', 2, 1), ('6', 2, 2), ('*', 2, 3),
            ('1', 3, 0), ('2', 3, 1), ('3', 3, 2), ('-', 3, 3),
            ('0', 4, 0), ('.', 4, 1), ('=', 4, 2), ('+', 4, 3)
        ]

        for (text, row, col) in buttons:
            btn = tk.Button(self, text=text, font=('Arial', 14),
                            command=lambda t=text: self.on_button_click(t))
            btn.grid(row=row, column=col, sticky='nsew', padx=2, pady=2)

        #control buttons
        clear_btn = tk.Button(self, text='C', font=('Arial', 14), command=self.clear)
        clear_btn.grid(row=5, column=0, columnspan=2, sticky='nsew', padx=2, pady=2)

        backspace_btn = tk.Button(self, text='⌫', font=('Arial', 14), command=self.backspace)
        backspace_btn.grid(row=5, column=2, columnspan=2, sticky='nsew', padx=2, pady=2)

        #history listbox
        self.history_listbox = tk.Listbox(self, font=('Arial', 12))
        self.history_listbox.grid(row=0, column=4, rowspan=6, sticky='nsew', padx=10, pady=10)
        self.history_listbox.bind('<<ListboxSelext>>', self.on_history_select)

        #configure grid weights
        for i in range(5):
            self.rowconfigure(i, weight=1)
        for i in range(5):
            self.columnconfigure(i, weight=1 if i <4 else 2)

    def on_key_press(self, event):
        """Handle keyboard input for numbers, operators, and controll"""
        key = event.char
        keysym = event. keysym

        #number keys(main and keypad)
        if key in '0123456789':
            self.on_button_click(key)
        elif keysym.startswith('KP_') and len(keysym) == 4 and keysym[3] in '0123456789':
            self.on_button_click(keysym[3])
        
        #decimal point
        elif key == '.' or keysym == 'KP_Decimal':
            self.on_button_click('.')

        #operators
        elif key in '+-*/':
            self.on_button_click(key)
        elif keysym in ['Key_Add', 'Key_Subtract', 'KP_Multiply', 'KP_Divide']:
            operator_map = {
                'KP_Add': '+',
                'KP_Subtract': '-',
                'KP_Multiply': '*',
                'KP_Divide': '/',
            }
            self.on_button_click(operator_map[keysym])
        
        #equals/enter
        elif keysym in ('Return', 'Kp_Enter') or key == '=':
            self.on_button_click('=')

        #backspace
        elif keysym == 'Backspace':
            self.backspace()

        #clear
        elif keysym == 'Escape':
            self.clear()

        return 'break' #Prevent default entry behavior

    def on_button_click(self, char):
        if char == '=':
            self.calculate()
        else:
            current = self.display.get()
            self.display.delete(0, tk.END)
            self.display.insert(tk.END, current + char)

    def calculate(self):
        try:
            expression = self.display.get()
            if not expression:
                return
            result = eval(expression)
            history_entry = f"{expression} = {result}"

            self.history.append({'expression' : expression, 'result': result})
            self.history_listbox.insert(tk.END, history_entry)

            self.display.delete(0, tk.END)
            self.display.insert(tk.END, str(result))
        except Exception as e:
            messagebox.showerror("Error", f"Invalid expression: {e}")

    def clear(self):
        self.display.delete(0, tk.END)

    def backspace(self):
        current = self.dispaly.get()[:-1]
        self.display.delete(0, tk.END)
        self.display.insert(0, current)

    def on_history_select(self, event):
        try:
            index = self.history_listbox.curselection()[0]
            selected_entry = self.history[index]
            self.display.delete(0, tk.END)
            self.display.insert(0, selected_entry['expression'])
        except IndexError:
            pass

if __name__ == "__main__":
    app = Calculator()
    app.mainloop()
