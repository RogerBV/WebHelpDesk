<template>
    <div id="login">
        <div class="row">
            <div class="col-md-4"></div>
            <div v-if="errors.length" class="alert alert-danger col-md-4" role="alert">
                <ul>
                    <li v-for="error in errors">{{ error }}</li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <img class="rounded" src="../../Img/logo2.png" />
        </div>
        <div class="w-25 p-3"></div>
        <div class="row">
            <div class="col-md-4"></div>

            <input type="text" id="txtUser" name="txtUser" v-model="txtUser" class="form-control col-md-3" placeholder="User" />

        </div>
        <div class="w-5 p-3"></div>
        <div class="row">
            <div class="col-md-4"></div>
            <input type="password" id="txtPass" name="txtPass" v-model="txtPass" class="form-control col-md-3" placeholder="Password" />
        </div>
        <div class="w-5 p-3"></div>
        <div class="row">
            <div class="col-md-4"></div>
            <button style="font-weight: bold; display: flex; justify-content: center;" class="btn btn-warning col-md-3 text-white" v-on:click="LoginAuthenticate">Login</button>
        </div>
    </div>
</template>
<script>
    import axios from 'axios';
    export default {
        el: '#login',
        name: "login-component",
        data() {
            return {
                errors:[],
                modules: [],
                txtUser: '',
                txtPass:''
            }
        },
        methods: {
            LoginAuthenticate() {
                if (this.Validate()) {
                    axios.post("/Login/LoginAuthenticate", null, { params: { user: this.txtUser, pass: this.txtPass } })
                    .then(response => {
                        if (response.data == 1) {
                            window.location.href = 'Menu'
                        } else {
                            this.errors = [];
                            this.errors.push('Failed Login');
                        }
                            
                    });
                }
            },
            Validate() {
                this.errors = [];
                if (this.txtUser == '') {
                    this.errors.push('The field User is empty.');
                    return false;
                }
                if (this.txtPass == '') {
                    this.errors.push('The field Password is empty.');
                    return false;
                }
                return true;
            }
        }, mounted() {
            
        }
    }
</script>
