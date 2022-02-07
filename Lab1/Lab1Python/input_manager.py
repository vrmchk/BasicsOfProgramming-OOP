def get_text_from_user() -> list[str]:  # отримати текст від користувача
    text = []
    lines_count = int(input("Enter number of lines: "))
    print("Enter your text:")
    for i in range(lines_count):
        s = input()
        text.append(s)

    return text
