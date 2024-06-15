CREATE TABLE public.produto (
	id SERIAL NOT NULL PRIMARY KEY,
	nome VARCHAR(255) NULL,    
    preco_unitario FLOAT NULL,	
	tipo INT NOT NULL
);