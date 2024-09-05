USE GeladeiraApiBD;

-- Criação da tabela Itens
CREATE TABLE Itens (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Categoria NVARCHAR(50) NOT NULL,
    Prateleira INT NOT NULL,
    Container INT NOT NULL,
    Posicao INT NOT NULL
);

-- Inserção de dados iniciais
INSERT INTO Itens (Nome, Categoria, Prateleira, Container, Posicao) VALUES
('Acelga', 'Hortifruti', 0, 0, 0),
('Alface', 'Hortifruti', 0, 0, 1),
('Batata', 'Hortifruti', 0, 0, 2),
('Beterraba', 'Hortifruti', 0, 0, 3),
('Cenoura', 'Hortifruti', 0, 1, 0),
('Couve', 'Hortifruti', 0, 1, 1),
('Pepino', 'Hortifruti', 0, 1, 2),
('Tomate', 'Hortifruti', 0, 1, 3),
('Atum em lata', 'Laticínios e Enlatados', 1, 0, 0),
('Leite', 'Laticínios e Enlatados', 1, 0, 1),
('Queijo', 'Laticínios e Enlatados', 1, 0, 2),
('Manteiga', 'Laticínios e Enlatados', 1, 0, 3),
('Requeijão', 'Laticínios e Enlatados', 1, 1, 0),
('Creme de leite', 'Laticínios e Enlatados', 1, 1, 1),
('Milho em conserva', 'Laticínios e Enlatados', 1, 1, 2),
('Ervilha em conserva', 'Laticínios e Enlatados', 1, 1, 3),
('Carne Moída', 'Carnes, Charcutaria e Ovos', 2, 0, 0),
('Frango', 'Carnes, Charcutaria e Ovos', 2, 0, 1),
('Carne bovina', 'Carnes, Charcutaria e Ovos', 2, 0, 2),
('Ovos', 'Carnes, Charcutaria e Ovos', 2, 0, 3),
('Salame', 'Carnes, Charcutaria e Ovos', 2, 1, 0),
('Bacon', 'Carnes, Charcutaria e Ovos', 2, 1, 1),
('Linguiça', 'Carnes, Charcutaria e Ovos', 2, 1, 2),
('Peito de Peru', 'Carnes, Charcutaria e Ovos', 2, 1, 3);
