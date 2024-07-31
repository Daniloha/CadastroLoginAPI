create Table IF NOT EXISTS Pessoas(
    ID LONGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Sobrenome VARCHAR(100) NOT NULL,
    Genero VARCHAR(100) NOT NULL,
    DataNascimento DATE NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefone VARCHAR(100) NOT NULL,
    Cpf VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL
)

INSERT INTO Pessoas (Nome, Sobrenome, Genero, DataNascimento, Email, Telefone, Cpf, Senha)
VALUES ('Joaquim', 'da Silva', 'Masculino', '2022-05-10', 'j@j.com', '123456789', '11111111111', '123');