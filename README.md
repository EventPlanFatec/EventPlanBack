## **Documentação da API - Evento**

### **Operações da API - Evento**

#### **Criar um Evento**

**Descrição**  
Esta operação cria um novo evento.

**Requisição**

```http
POST /api/events
```

**Corpo da Requisição**

```json
{
  "nomeEvento": "Workshop de Programação",
  "descricao": "Evento focado em boas práticas de Clean Code.",
  "dataInicio": "2024-11-08T09:00:00",
  "dataFim": "2024-11-08T18:00:00",
  "horarioInicio": "09:00:00",
  "horarioFim": "18:00:00",
  "lotacaoMaxima": 100,
  "endereco": {
    "tipoLogradouro": "Rua",
    "logradouro": "Av. Paulista",
    "numeroCasa": "1000",
    "bairro": "Bela Vista",
    "cidade": "São Paulo",
    "estado": "SP",
    "cep": "01310-100"
  },
  "imagens": [
    "https://exemplo.com/imagem1.jpg"
  ],
  "video": "https://exemplo.com/video.mp4",
  "notaMedia": 4.8,
  "genero": "Tecnologia",
  "usuariosFinais": [],
  "ingressos": [],
  "organizacaoId": 4,
  "isPrivate": true,
  "senha": "eventoSegreto123"
}
```

---

#### **Retornar Todos os Eventos**

**Descrição**  
Esta operação retorna todos os eventos.

**Requisição**

```http
GET /api/events
```

**Resposta**

```json
[
  {
    "nomeEvento": "Evento Exemplo",
    "dataInicio": "2024-10-02T19:30:18.647Z",
    "dataFim": "2024-10-02T19:30:18.647Z"
  }
]
```

---

#### **Retornar um Evento Específico**

**Descrição**  
Esta operação retorna um evento específico com base no ID.

**Requisição**

```http
GET /api/events/{id}
```

**Parâmetros**

| Parâmetro | Tipo | Descrição                             |
| :-------- | :--- | :------------------------------------ |
| `id`      | `int`| **Obrigatório**. O ID do evento a ser retornado. |

**Resposta**

```json
{
  "eventoId": 1,
  "nomeEvento": "Evento Exemplo",
  "dataInicio": "2024-10-02T19:30:18.647Z",
  "dataFim": "2024-10-02T19:30:18.647Z"
}
```

---

#### **Atualizar um Evento**

**Descrição**  
Esta operação atualiza um evento existente.

**Requisição**

```http
PUT /api/events/{id}
```

**Parâmetros**

| Parâmetro | Tipo | Descrição                             |
| :-------- | :--- | :------------------------------------ |
| `id`      | `int`| **Obrigatório**. O ID do evento que será atualizado. |

**Corpo da Requisição**

```json
{
  "eventoId": 1,
  "nomeEvento": "Novo Nome do Evento",
  "dataInicio": "2024-10-02T19:30:18.647Z",
  "dataFim": "2024-10-02T19:30:18.647Z",
  "horarioInicio": "14:00:00",
  "horarioFim": "16:00:00",
  "lotacaoMaxima": 100,
  "tipoLogradouro": "Rua",
  "logradouro": "Rua Exemplo",
  "numeroCasa": "123",
  "bairro": "Centro",
  "cidade": "Cidade Exemplo",
  "estado": "SP",
  "cep": "01234-567",
  "tipo": "Cultural",
  "imagem01": "http://exemplo.com/imagem1.jpg",
  "imagem02": "http://exemplo.com/imagem2.jpg",
  "imagem03": "http://exemplo.com/imagem3.jpg",
  "video": "http://exemplo.com/video.mp4",
  "notaMedia": 4.5,
  "genero": "Música",
  "organizacaoId": 1
}
```

---

#### **Deletar um Evento**

**Descrição**  
Esta operação remove um evento existente.

**Requisição**

```http
DELETE /api/events/{id}
```

**Parâmetros**

| Parâmetro | Tipo | Descrição                             |
| :-------- | :--- | :------------------------------------ |
| `id`      | `int`| **Obrigatório**. O ID do evento a ser removido. |

**Resposta de Sucesso**

```
204 No Content
```

**Resposta se o evento não for encontrado**

```json
{
  "message": "Event with ID {id} not found."
}
```

## **Modelo - EventoDTO**

### **Descrição**
O `EventoDTO` é um objeto de transferência de dados que representa as informações de um evento. Este modelo é utilizado para criar, atualizar e retornar dados relacionados a um evento em sistemas de planejamento de eventos.

### **Propriedades**

| Propriedade        | Tipo       | Descrição                                                             |
| :----------------- | :--------- | :-------------------------------------------------------------------- |
| `EventoId`        | `int`      | **Identificador único** do evento.                                   |
| `NomeEvento`      | `string`   | **Nome** do evento.                                                  |
| `DataInicio`      | `DateTime` | **Data e hora** de início do evento.                                 |
| `DataFim`         | `DateTime` | **Data e hora** de término do evento.                                |
| `HorarioInicio`    | `TimeSpan` | **Hora de início** do evento.                                        |
| `HorarioFim`      | `TimeSpan` | **Hora de término** do evento.                                       |
| `LotacaoMaxima`   | `int`      | **Capacidade máxima** de participantes do evento.                    |
| `TipoLogradouro`  | `string`   | **Tipo de logradouro** (ex: Rua, Avenida) onde o evento ocorre.     |
| `Logradouro`      | `string`   | **Nome do logradouro** onde o evento ocorre.                         |
| `NumeroCasa`      | `string`   | **Número** da casa ou local onde o evento acontece.                  |
| `Bairro`          | `string`   | **Bairro** onde o evento ocorre.                                     |
| `Cidade`          | `string`   | **Cidade** onde o evento é realizado.                                |
| `Estado`          | `string`   | **Estado** onde o evento é realizado.                                |
| `CEP`             | `string`   | **Código de Endereçamento Postal** onde o evento ocorre.             |
| `Tipo`            | `string`   | **Tipo** do evento (ex: Festival, Conferência).                      |
| `Imagem01`       | `string`   | URL da **primeira imagem** do evento.                                |
| `Imagem02`       | `string`   | URL da **segunda imagem** do evento.                                 |
| `Imagem03`       | `string`   | URL da **terceira imagem** do evento.                                |
| `Video`           | `string`   | URL do **vídeo** relacionado ao evento.                              |
| `NotaMedia`       | `decimal`  | **Nota média** do evento, se aplicável.                             |
| `Genero`          | `string`   | **Gênero** do evento, se aplicável (ex: Música, Teatro).            |
| `OrganizacaoId`   | `int`      | **Identificador** da organização responsável pelo evento.            |

## **Documentação da API - Favoritos**

### **Operações da API - Favoritos**

---

#### **Adicionar um Evento aos Favoritos**

**Descrição**  
Adiciona um evento à lista de favoritos do usuário autenticado.

**Requisição**

```http
POST /api/favorites
```

**Parâmetros da Query**

| Parâmetro | Tipo   | Obrigatório | Descrição                          |
| :-------- | :----- | :---------- | :--------------------------------- |
| `eventId` | `int`  | Sim         | ID do evento a ser favoritado.     |

**Cabeçalho**

| Chave         | Obrigatório | Descrição                         |
| :------------ | :---------- | :-------------------------------- |
| `Authorization` | Sim         | Token de autenticação do usuário.|

**Resposta de Sucesso**

```json
{
  "status": "success",
  "message": "Evento adicionado aos favoritos."
}
```

**Resposta de Erro**

- **401 Unauthorized**  
  ```json
  {
    "status": "error",
    "message": "Usuário não autenticado."
  }
  ```

- **400 Bad Request**  
  ```json
  {
    "status": "error",
    "message": "Este evento já está nos favoritos."
  }
  ```

---

#### **Listar Favoritos de um Usuário**

**Descrição**  
Retorna a lista de eventos favoritados por um usuário específico.

**Requisição**

```http
GET /api/favorites/{userId}
```

**Parâmetros**

| Parâmetro | Tipo     | Obrigatório | Descrição                                   |
| :-------- | :------- | :---------- | :----------------------------------------- |
| `userId`  | `string` | Sim         | ID do usuário cujos favoritos serão listados. |

**Resposta de Sucesso**

```json
{
  "status": "success",
  "data": [
    {
      "eventId": 1,
      "nomeEvento": "Workshop de Programação",
      "dataInicio": "2024-11-08T09:00:00",
      "dataFim": "2024-11-08T18:00:00",
      "local": "São Paulo - SP"
    }
  ]
}
```

**Resposta de Erro**

- **404 Not Found**  
  ```json
  {
    "status": "error",
    "message": "Nenhum favorito encontrado."
  }
  ```

- **500 Internal Server Error**  
  ```json
  {
    "status": "error",
    "message": "Erro ao buscar favoritos."
  }
  ```

---

#### **Remover um Evento dos Favoritos**

**Descrição**  
Remove um evento da lista de favoritos do usuário autenticado.

**Requisição**

```http
DELETE /api/favorites/{eventId}
```

**Parâmetros**

| Parâmetro | Tipo   | Obrigatório | Descrição                          |
| :-------- | :----- | :---------- | :--------------------------------- |
| `eventId` | `int`  | Sim         | ID do evento a ser removido.       |

**Cabeçalho**

| Chave         | Obrigatório | Descrição                         |
| :------------ | :---------- | :-------------------------------- |
| `Authorization` | Sim         | Token de autenticação do usuário.|

**Resposta de Sucesso**

```json
{
  "status": "success",
  "message": "Evento removido dos favoritos."
}
```

**Resposta de Erro**

- **400 Bad Request**  
  ```json
  {
    "status": "error",
    "message": "Este evento não está nos favoritos."
  }
  ```

- **500 Internal Server Error**  
  ```json
  {
    "status": "error",
    "message": "Erro ao remover o evento dos favoritos."
  }
  ```
