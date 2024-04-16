# HTTP, REST

## HTTP
- HTTP?
  - Hypertext Transfer Protocol
  - It's a standard protocol for transfering data over web

- Req/Res Lifecycle work?
    1. Client sends request to the server
       1. Address -> IP via DNS
       2. Send HTTP Request
    2. Server processes the request and send an appropriate response

- What is inside HTTP Request?
  - URI ("Where are we going/what do we want?")
  - Method Verbs(GET, POST, PUT, DELETE, PATCH, OPTIONS, TRACE)
  - Header
    - Generally, information that describes the request itself(metadata about the request)
    - Can contain
      - Auth tokens
      - Accept ("What are we requesting")
  - Body (optional)
    - if you have more complex data to communicate
    - usually sent with POST/PUT requests

- What is inside HTTP Response?
  - Status Code
    - 100: Informational
    - 200: Success (200 OK, 201 Created, 204 No Content)
    - 300: Redirection (resource Used to be here, but not here anymore. redirecting you to the right url)
    - 400: Client Error (404 Not Found: NOT TO BE USED WHEN THE URL IS CORRECT BUT NO RESOURCES ARE THERE, 400: Bad Request, 401: Unauthorized, 403: Forbidden)
    - 500: Server-side Error (Something went wrong on ourside, 503: Service Unavailable, 502 bad gateway) 
  - Response Header
    - Content-Type: This is the type of data we're giving it to you
  - Response Body

## REST (REpresentational State Transfer)
It's a design principle to build API's. RESTful API is an API that follows REST guideline

Six Guiding Principles of REST
1. Uniform Interface
2. Client Server
3. Stateless
4. Cacheable
5. Layered System
6. Code on Demand