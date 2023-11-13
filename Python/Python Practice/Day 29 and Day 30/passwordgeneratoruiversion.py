from tkinter import *
from tkinter import messagebox
import random
import pyperclip

EMAIL = "miller.christopher618@gmail.com"


# ---------------------------- PASSWORD GENERATOR ------------------------------- #


def generate_password():
    password_entry.delete(0, END)
    letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
               'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
               'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']
    numbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']
    symbols = ['!', '#', '$', '%', '&', '(', ')', '*', '+']
    nr_letters = random.randint(10, 15)
    nr_symbols = random.randint(3, 8)
    nr_numbers = random.randint(3, 8)
    total = nr_letters + nr_symbols + nr_numbers
    total_numbers = 0
    total_letters = 0
    total_symbols = 0
    password = ""
    chars = [letters, numbers, symbols]

    for n in range(0, total):
        char = random.randint(0, 2)
        while (char == 0 and total_letters == nr_letters) or (char == 1 and total_numbers == nr_numbers) or (
                char == 2 and total_symbols == nr_symbols):
            char = random.randint(0, 2)
        if char == 0 and total_letters < nr_letters:
            char = random.randint(0, len(letters) - 1)
            password += chars[0][char]
            total_letters += 1
        elif char == 1 and total_numbers < nr_numbers:
            char = random.randint(0, len(numbers) - 1)
            password += chars[1][char]
            total_numbers += 1
        elif char == 2 and total_symbols < nr_symbols:
            char = random.randint(0, len(symbols) - 1)
            password += chars[2][char]
            total_symbols += 1

    password_entry.insert(END, password)
    pyperclip.copy(password)


# ---------------------------- SAVE PASSWORD ------------------------------- #

def save_data():
    if len(email_username_entry.get().strip()) == 0 or len(password_entry.get().strip()) == 0 or len(
            website_entry.get().strip()) == 0:
        messagebox.showerror(title="Error", message="All fields cannot be empty")
    else:
        result = messagebox.askokcancel(title=website_entry.get(), message=f"Here are the details entered: \n"
                                                                           f"Email: {email_username_entry.get()}\n"
                                                                           f"Password: {password_entry.get()}\n"
                                                                           f"Is it okay to save?")
        if result:
            with open("data.txt", mode="a") as file:
                file.write(f"{website_entry.get()} | {email_username_entry.get()} | {password_entry.get()}\n")

            website_entry.delete(0, END)
            password_entry.delete(0, END)


# ---------------------------- UI SETUP ------------------------------- #
window = Tk()
window.title("Password Generator")
window.config(padx=50, pady=50)

canvas = Canvas(width=200, height=200)
image = PhotoImage(file="logo.png")
canvas.create_image(100, 100, image=image)
canvas.grid(column=1, row=0)

website_label = Label(text="Website:")
website_label.grid(column=0, row=1)
website_entry = Entry(width=52)
website_entry.focus()
website_entry.grid(column=1, row=1, columnspan=2)

email_username_label = Label(text="Email/Username:")
email_username_label.grid(column=0, row=2)
email_username_entry = Entry(width=52)
email_username_entry.grid(column=1, row=2, columnspan=2)
email_username_entry.insert(END, EMAIL)

password_label = Label(text="Password:")
password_label.grid(column=0, row=3)
password_entry = Entry(width=33, text="")
password_entry.grid(column=1, row=3)
generate_password_button = Button(text="Generate Password", command=generate_password)
generate_password_button.grid(column=2, row=3)

add_button = Button(text="Add", width=44, command=save_data)
add_button.grid(column=1, row=4, columnspan=2)

window.mainloop()
