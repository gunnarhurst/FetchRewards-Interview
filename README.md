# PointsApi

## Overview:
This is a REST API web service that accepts HTTP requests and returns responses based on conditions outlined here: 
## Background:
* Users have points in their account from various payers.
* The Payer will post transactions to either add or deduct points from the user's account.
  * A single Payer's total points cannot be less than zero.
* A User's points can be spent
  * The user's total points cannot be less than zero.
  * The points will be spent according to timestamp on each transaction regardless of the payer.

## How to run:
1. Clone the repository.
   * `git clone https://github.com/gunnarhurst/PointsApi.git`
3. Navigate to the root directory for the project
   * `cd filepath\to\PointsApiApp`
4. Build the project.
   * `dotnet build`
5. Run the project
   * `dotnet run`
   - At this point, the project should run. You will see something like:
     "Now listening on: `https://localhost:XXXX` where XXXX is the port number."
5. Point your browser to `https://localhost:XXXX/swagger/index.html`
6. Use Swagger UI to run the project according to endpoints in next section.

## Endpoints:
### POST localhost:####/Points/add
* This endpoint is the starting place for running the project. We will add our transactions here.
1. Expand the `/Points/add` endpoint.
2. Click "Try it out"
3. Enter a transaction in the "Request Body."
   - ****NOTE:**** Transactions must be entered one at a time.
   
 `{
 "payer": "string",
 "points": 0,
 "timestamp": "2022-06-16T02:40:36.427Z"
 }`
 <img width="1490" alt="Screen Shot 2022-06-16 at 4 27 40 PM" src="https://user-images.githubusercontent.com/44716181/174187643-e2677051-e1ad-4025-8c42-9a6bc7a13965.png">

4. Select ***Execute*** after entering each transaction.

<img width="1490" alt="Screen Shot 2022-06-16 at 4 31 12 PM" src="https://user-images.githubusercontent.com/44716181/174187453-fb91b393-a0c5-453c-baa7-6606c7fb185d.png">

5. Repeat until you've entered all the transactions you're testing.

#### Test Data ###
- `{ "payer": "DANNON", "points": 1000, "timestamp": "2020-11-02T14:00:00Z" }`
- `{ "payer": "UNILEVER", "points": 200, "timestamp": "2020-10-31T11:00:00Z" }`
- `{ "payer": "DANNON", "points": -200, "timestamp": "2020-10-31T15:00:00Z" }`
- `{ "payer": "MILLER COORS", "points": 10000, "timestamp": "2020-11-01T14:00:00Z" }`
- `{ "payer": "DANNON", "points": 300, "timestamp": "2020-10-31T10:00:00Z" }`

### POST localhost:####/Points/spend
* This endpoint is for spending our points according to these rules:
  - Oldest points must be spent first according to timestamp for each transaction.
  - No single payer's points balance can go negative.

1. Expand the `/Points/spend` endpoint.
2. Click ***Try it out***

3. Enter amount to be spent in the "Request Body."
 `{
 "points": 0
 }`
 
4. Select ***Execute***
<img width="1470" alt="Screen Shot 2022-06-16 at 4 35 43 PM" src="https://user-images.githubusercontent.com/44716181/174187047-4570aabe-b845-4510-b359-9348068ded39.png">
5. The "Response Body" will return a list of each payer and how many points were deducted from their total points.
<img width="1433" alt="Screen Shot 2022-06-16 at 4 37 13 PM" src="https://user-images.githubusercontent.com/44716181/174187208-8a1a0eac-b5a3-4ad3-b452-c48057b2eede.png">

#### Test Data ###
- `{ "points": 5000 }`

### GET localhost:####/Points/balance
* This endpoint is for returning the total balances for each payer.

1. Expand the `/Points/balance` endpoint.
2. Click ***Try it out***
3. Select ***Execute***

* You should see the remaining payer points balances in the response body:  
<img width="1433" alt="Screen Shot 2022-06-16 at 4 37 53 PM" src="https://user-images.githubusercontent.com/44716181/174186172-510ae358-528a-4903-a776-cd0074791947.png">

#### Test Data ###
    [
    { "payer": "DANNON", "points": -100 },
    { "payer": "UNILEVER", "points": -200 },
    { "payer": "MILLER COORS", "points": -4,700 }
    ]
    
