<!-- 
# How this project work -->
# Clone and Test!
For now, I just made the authentication work with ASP.NET Identity with roles (I still need to refactor both APIs, they are way different than the course).

To test this project run: 
```bash
git clone https://github.com/Saraivinha1703/full-cycle-show-ticket.git
```

inside the `full-cycle-show-ticket/caticket` project folder, rename the `.env.example` to `.env`.

Now, you just need to have docker or podman installed and run `docker compose up -d` and test the authentication from the website provided at `http://localhost:3000`.

# Project Development Idea
<blockquote>
<small>
<b>NOTE:</b> This project was done following the <code>Imersão Full Stack && FullCycle</code> course by <code>Wesley Willians</code> 🥳🥳🥳. Check it out <a href="https://imersao.fullcycle.com.br/">here</a>
and their <a href="https://youtube.com/fullcycle">youtube channel</a>.
</small>
</blockquote>
<br/>
Develop a system to sell ticket for shows, managing the events and the booking process. Integration with other partner systems.

Tasks:
- Manage events / process booking
    - Integration with partner systems 
- Partners systems
- Front-end
- API Gateway

<!-- # Workflow
--- change to a graph ---

front end -> API Gateway -> system interface -> events management system -> partners API -->

# Technologies

- Docker
- Microservices with C#
- Front-end with Next.js
- Kong API Gateway

# Development Order

- Partners API <small><small>`Microservice with C#`</small></small>
- Ticket management system <small><small>`Microservice with C#`</small></small>
- Front-end <small><small>`Next.js`</small></small>
- API Gateway <small><small>`Kong`</small></small>
<br/>
<br/>
<blockquote><b>NOTE:</b> All the mentions of the word <i>'Partner'</i> refers to the entity that is emiting and selling this tickets, and they are considered <i>partners</i> of this selling ticket platform.</blockquote>
