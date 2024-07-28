import { Given, Then, When } from '@cucumber/cucumber';

import { Ensure, equals, contain, containAtLeastOneItemThat, property } from '@serenity-js/assertions'
import { actorCalled, Cast, engage } from '@serenity-js/core'
import { CallAnApi, GetRequest, LastResponse, Send } from '@serenity-js/rest'

const happyFeeling = 'happy';

When('{actor} requests to see the menu', async (actor) => {
    await actor.attemptsTo(
        Send.a(GetRequest.to('1')),
        Ensure.that(LastResponse.status(), equals(200)),
    )
})

When('the menu contains {pronoun} favorite dish, {string}', async (actor, favoriteDish) => {
    await actor.attemptsTo(
        Ensure.that(
            LastResponse.body().items, containAtLeastOneItemThat(property('name', equals(favoriteDish)))
        ),
    )
})

Then('{pronoun} feels {string}, and is satisfied', async (actor, feeling) => {
    await actor.attemptsTo(
        Ensure.that(feeling, equals(happyFeeling)
        ),
    )
})