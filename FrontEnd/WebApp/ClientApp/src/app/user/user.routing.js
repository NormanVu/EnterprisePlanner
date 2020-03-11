"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var registration_form_component_1 = require("../user/registration-form/registration-form.component");
var login_form_component_1 = require("../user/login-form/login-form.component");
exports.RoutingUser = router_1.RouterModule.forChild([
    { path: 'register', component: registration_form_component_1.RegistrationFormComponent },
    { path: 'login', component: login_form_component_1.LoginFormComponent }
]);
//# sourceMappingURL=user.routing.js.map