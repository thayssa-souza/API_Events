# API_Events
## Projeto final do módulo de Programação Web 3 - Curso Web Full Stack Let's Code

### Objetivo:

Construir uma API que registre e manipule eventos que acontecem na cidade, como shows, peças de teatro, eventos especiais em restaurantes, entre outros.
Implementar a documentação completa da API, utilizando Swagger. Construir uma API, com um cadastro de eventos e um cadastro de reservas, respeitando as diretrizes de REST, SOLID e os princípios base de arquitetura.
 
 
### Métodos CityEvent:

•	Inclusão de um novo evento; *Autenticação e Autorização admin

•	Edição de um evento existente, filtrando por id; *Autenticação e Autorização admin

•	Remoção de um evento, caso o mesmo não possua reservas em andamento, caso possua inative-o; *Autenticação e Autorização admin

•	Consulta por título, utilizando similaridades, por exemplo, caso pesquise Show, traga todos os eventos que possuem a palavra Show no título;

•	Consulta por local e data;

•	Consulta por range de preço e a data;


### Métodos EventReservation:

•	Inclusão de uma nova reserva; *Autenticação

•	Edição da quantidade de uma reserva; *Autenticação e Autorização admin

•	Remoção de uma reserva; *Autenticação e Autorização admin

•	Consulta de reserva pelo PersonName e Title do evento, utilizando similaridade para o title; *Autenticação
