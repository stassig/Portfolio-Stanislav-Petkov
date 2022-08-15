describe('Login Page', () => {

    it('should login and logout successfully', () => {
        cy.visit('/login')
            .get('#login-username').clear().type("test")
            .get('#login-password').clear().type("test")
            .get('#login-button').click();
        cy.wait(2000)
            .get('#logout-button').click();
        cy.hash().should('eq', '');
    })
})