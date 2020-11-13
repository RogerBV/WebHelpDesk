import Vue from 'vue'
import Router from 'vue-router';
import HomeComponent from './Home/home.vue'
import ModuleComponent from './Module/module.vue'
import RequestComponent from './Request/request.vue'
import LoginComponent from './Login/login.vue'
import MenuComponent from './Menu/menu.vue'
import AttentionComponent from './Request/attention.vue'
import AssignRequestComponent from './Request/assignRequest.vue';
Vue.use(Router);

var router = new Router({
    routes: [
        {
            path: '/Request',
            name: 'Request',
            component:RequestComponent
        },
        {
            path: '/Module',
            name: 'Module',
            component:RequestComponent
        },
        {
            path: '/Attention',
            name: 'Attention',
            component: AttentionComponent
        }, {
            path: '/AssignRequest',
            name: 'AssignRequest',
            component: AssignRequestComponent
        }

    ]
})


new Vue({
    el: '#app',
    router: router,
    
    components: {
        HomeComponent,
        ModuleComponent,
        RequestComponent,
        AssignRequestComponent,
        AttentionComponent,
        LoginComponent,
        MenuComponent
    },
})