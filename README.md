# Desafio Fullstack - Plataforma de Monitoramento IoT

Este projeto consiste em uma aplicação web Fullstack desenvolvida como parte de um desafio técnico para integrar e monitorar dispositivos IoT de uma plataforma colaborativa, facilitando a tomada de decisões no setor agrário.

## 📋 Descrição do Projeto

O objetivo desta aplicação é permitir que os usuários autentiquem-se, selecionem dispositivos IoT de uma plataforma colaborativa e monitorem as medições de seus sensores em tempo real. A plataforma será capaz de:

- Autenticação de usuários.
- Seleção de dispositivos IoT para monitoramento.
- Configuração de comandos de coleta de métricas dos dispositivos.
- Dashboard para exibição de medições em tempo real.
- Comunicação com dispositivos via protocolo Telnet.

## 🛠️ Tecnologias Utilizadas

- **Front-end:** React.js + TypeScript
- **Back-end:** .NET Core Web API
- **Banco de Dados:** PostgreSQL
- **Autenticação:** JWT (JSON Web Tokens)
- **Protocolo de Comunicação:** Telnet
- **Containerização:** Docker

## 📦 Arquitetura e Decisões de Design

- **Arquitetura em Camadas:** Separação entre camadas de apresentação, aplicação, domínio e infraestrutura.
- **API RESTful:** Organização de rotas e métodos HTTP respeitando o padrão REST.
- **Telnet Async:** Comunicação com os dispositivos via Telnet utilizando operações assíncronas para otimizar o tempo de resposta.
- **Segurança:** Implementação de autenticação baseada em tokens JWT.
- **Eficiência:** Implementação de cache de resultados para otimizar as requisições frequentes.

## 🚀 Instalação e Execução

1. Clone o repositório:

   ```bash
   git clone https://github.com/seuusuario/desafio-fullstack-iot.git
   cd desafio-fullstack-iot
