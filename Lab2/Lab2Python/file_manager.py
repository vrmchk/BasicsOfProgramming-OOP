import datetime
from datetime import timedelta


def create_file(path, text: str):  # створення файлу
    with open(path, "wb") as file:
        byte_text = str.encode(text)
        file.write(byte_text)


def append_to_file(path, text: str):  # доповнення файлу
    with open(path, "ab") as file:
        byte_text = str.encode(text)
        file.write(byte_text)


def read_all_from_file(path) -> str:  # зчитування з файлу
    byte_array = []
    with open(path, "rb") as file:
        byte_array = file.read()
    return byte_array.decode()


def print_all_file(path: str):  # вивід з файлу
    file_name = path[path.rindex("\\") + 1:]
    print(f"\nFile name is {file_name}")
    text = read_all_from_file(path).split('\n')
    for i in range(len(text)):
        if (i + 1) % 3 == 0:
            print("Gadget")
            print(f"Name: {text[i - 2]}")
            print(f"Purchase date: {text[i - 1]}")
            print(f"Warranty time: {text[i]}")
            print()


def fill_file_from_console(path):  # заповнення файлу з консолі
    gadget_count = int(input("Enter number of gadgets: "))
    gadgets = []
    for i in range(gadget_count):
        gadget_name = input("Enter the name of gadget: ")
        input_date = input("Enter gadget's date of purchase (__.__.____): ")
        purchase_date = datetime.datetime.strptime(input_date, "%d.%m.%Y").date()
        warranty_time = int(input("Enter gadget's warranty time (days): "))
        gadgets.append((gadget_name, purchase_date, warranty_time))
        print()

    create_file(path, convert_gadgets_to_text(gadgets))


def get_gadgets_from_file(path) -> list[tuple]:  # зчитування інформації про гаджети з файлу
    text_from_file = read_all_from_file(path).split('\n')
    gadgets = []

    for i in range(len(text_from_file)):
        if (i + 1) % 3 == 0:
            gadget_name = text_from_file[i - 2]
            purchase_date = datetime.datetime.strptime(text_from_file[i - 1], "%Y-%m-%d").date()
            warranty_time = int(text_from_file[i])
            gadgets.append((gadget_name, purchase_date, warranty_time))

    return gadgets


def get_not_warranty_gadgets(gadgets: list[tuple]) -> list[tuple]:  # отримати гаджети не на гарантії
    return [gadget for gadget in gadgets if gadget[1] + timedelta(gadget[2]) < datetime.datetime.today().date()]


def convert_gadgets_to_text(gadgets: list[tuple]) -> str:  # перетворити інформацію про гаджети в текст
    text = ''
    for gadget in gadgets:
        text += f"{gadget[0]}\n{gadget[1]}\n{gadget[2]}\n"
    return text
