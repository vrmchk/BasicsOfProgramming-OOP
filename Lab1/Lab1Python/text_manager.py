def split_text_to_new_lines(string: str) -> list[str]:  # розбивання речення по рядочкам
    return string.replace(". ", ".\n").split('\n')


def define_longest_in_string(string: str) -> str:  # знайти найдовше слово, поставити на початок його і довжину
    words = string.replace(',', '').replace('.', '').split()
    max_word = ""
    len_of_max_word = 0

    for word in words:
        if len(word) > len_of_max_word:
            max_word = word
            len_of_max_word = len(word)

    return f"[{len_of_max_word} {max_word}] " + string


def define_longest_in_text(text: list[str]) -> list[str]:  # виконати завдання для всіх рядків
    result_text = []
    for line in text:
        result_text.append(define_longest_in_string(line))

    return result_text
