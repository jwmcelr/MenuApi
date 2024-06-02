import { Given, Then, When } from '@cucumber/cucumber';
import { spec } from 'pactum';
import { Ensure, equals } from '@serenity-js/assertions'
import { actorCalled, Cast, engage, Actor } from '@serenity-js/core'
import { CallAnApi, GetRequest, LastResponse, Send } from '@serenity-js/rest'
import { Page } from '@serenity-js/web'
import { PlaywrightPage } from '@serenity-js/playwright'
import { By, Text, PageElement } from '@serenity-js/web'
import { request, expect } from '@playwright/test';

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
        actor.whoCan(CallAnApi.at(baseURL))
    )                  // 1) Add ability
    )


    

    await actorCalled('Apisitt').attemptsTo(
        Send.a(GetRequest.to('1')),             // 2) Send request
        Ensure.that(LastResponse.status(), equals(200)),  // 3) Verify response
    )
});

Given('I\'ve looked at the items on it', async function () {
    // Write code here that turns the phrase above into concrete actions
    // return 'pending';
    
    // var serenityPage = page as PlaywrightPage;
    // var playwrightPage = await serenityPage.nativePage();

    // let apisittActor: Actor = await actorCalled('Apisitt');
    // const serenityPage = await apisittActor.answer(Page.current() as any) as PlaywrightPage

    // var playwrightPage = await serenityPage.nativePage();

    // Create a context that will issue http requests.
    const context = await request.newContext({
        baseURL: baseURL,
    });

    // Create a repository.
    const newIssue = await context.get('1');
    expect(newIssue.ok()).toBeTruthy();
    console.log("Hi Justin");
    console.log(await newIssue.json());
    console.log("Hi Justin2");
    expect(await newIssue.json()).toEqual({
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