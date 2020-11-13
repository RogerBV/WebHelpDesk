<template>
    <div id="menu" style="background-color:#ffffff">
        <nav class="navbar navbar-expand-lg navbar-light bg-light menu" >
            <img src="../../Img/miniLogo.png" />
            
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <router-link to="/request">
                            <a class="nav-link" href="#">Request <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item active">
                        <router-link to="/assignRequest">
                            <a class="nav-link" href="#">Assign Requests</a>
                    </li>
                    <li class="nav-item active">
                        <router-link to="/attention">
                            <a class="nav-link" href="#">Attentions</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link disabled" href="#">Disabled</a>
                    </li>
                </ul>
                <span v-on:click="LogOut" class="material-icons float-right">
                    power_settings_new
                </span>
            </div>
        </nav>
        <router-view></router-view>
    </div>
</template>
<style>
    .menu-bar {
        background-color: #EEBB07;
    }
    .menu {
        background-color: #000000;
    
    }
    .table-selected tr:hover {
        background-color: #F2D15D;
    }

    .center-cell {
        text-align:center;
    }

</style>
<script>
    import axios from 'axios';
    export default {
        el: '#menu',
        name: "menu-component",
        data() {
            return {
                user:[],
                modules: [],
                txtName: ''
            }
        }, methods: {
            ShowUserLogged: function (event) {
                axios.get("/Menu/ShowUserLogged", {
                    dataType: 'json', headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    mode: 'no-cors',
                    credentials: 'include'
                }).then(response => {
                    this.user = response.data;
                });
            }
            , LogOut() {
                axios.post("/Login/LogOut", null, { params: {  } })
                    .then(response => {
                        if (response.data == 1) {
                            window.location.href = 'Login'
                        } else {
        
                        }
                            
                    });
            }

            
        }, mounted() {
            this.ShowUserLogged();
        }
    }
</script>