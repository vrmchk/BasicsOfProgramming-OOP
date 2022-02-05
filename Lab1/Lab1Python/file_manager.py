def generate_file(file_name, text: str):  # створення і заповнення файлу
    file = open(file_name, "w")
    file.write(text)
    file.close()


def read_all_from_file(file_name) -> str:  # зчитування тексту з першого файлу
    file = open(file_name)
    result = '\n'.join(file.readlines())
    file.close()
    return result


def print_from_file(file_name):  # виведення тексту з файлу
    file = open(file_name)
    print(f"\nFile name is {file_name}")
    print(''.join(file.readlines()))
    file.close()
