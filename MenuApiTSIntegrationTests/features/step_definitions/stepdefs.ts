import { Given, Then, When } from '@cucumber/cucumber';
import { spec } from 'pactum';
import { Ensure, equals } from '@serenity-js/assertions'
import { actorCalled, Cast, engage } from '@serenity-js/core'
import { CallAnApi, GetRequest, LastResponse, Send } from '@serenity-js/rest'

const baseURL = 'https://localhost:7235/api/Menu/'

Given('the menu is available', async function () {
    // Write code here that turns the phrase above into concrete actions
    // return 'pending';
    await spec()
        .get('https://localhost:7235/api/Menu/1')
        // .withCore({ rejectUnauthorized: false })
        .expectStatus(200)
        .expectJsonLike({
            "id": 1,
            "items": [
                {
                    "id": 1,
                    "name": "Spaghetti",
                    "description": "A Delicious Noodly Dish with Spaghetti Sauce and Meatballs"
                },
                {
                    "id": 2,
                    "name": "Lasagna",
                    "description": "A plateful of Cheesy, Meaty Deliciousness"
                }
            ]
        });
});

Given('the playwright menu is available', async function () {
    // Write code here that turns the phrase above into concrete actions
    // return 'pending';
   
        engage(Cast.where(actor =>
            actor.whoCan(CallAnApi.at(baseURL)))                  // 1) Add ability
        )
    

    await actorCalled('Apisitt').attemptsTo(
        Send.a(GetRequest.to('1')),             // 2) Send request
        Ensure.that(LastResponse.status(), equals(200)),  // 3) Verify response
    )
});