import pandas

alpha_list = pandas.read_csv("nato_phonetic_alphabet.csv")
phonetic_dict = {row.letter: row.code for (index, row) in alpha_list.iterrows()}

name = input("What is your name?: ").upper()
letter_list = [code for alpha in name for (letter, code) in phonetic_dict.items() if alpha == letter]
print(letter_list)
