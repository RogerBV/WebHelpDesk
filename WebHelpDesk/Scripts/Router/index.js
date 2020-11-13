import Vue from 'vue'
import Router from 'vue-router'
import Menu from './../Menu';

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/Menu',
            name: 'Menu',
            component: Menu
        }
    ]
})