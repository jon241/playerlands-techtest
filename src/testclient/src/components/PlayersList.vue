<template>
    <div id="players">
        <p>All your players listed here.</p>
        <table id = "players-table">
            <tr>
                <th>User Name</th>
                <th>Email</th>
                <th>Date Joined</th>
            </tr>
            <tr v-for = "player in playersfound" :key = "player.userName">
                <td>{{player.userName}}</td>
                <td>{{player.email}}</td>
                <td>{{player.dateJoined}}</td>
            </tr>
        </table>
    </div>
</template>

<script>
// eslint-disable-next-line import/extensions
// eslint-disable-next-line import/no-unresolved
// eslint-disable-next-line import/extensions
import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
  name: 'PlayersList',
  data() {
    return {
      playersfound: [],
    };
  },
  created() {
    this.getPlayers();
  },
  methods: {
    getPlayers() {
      axios.get('/players')
        .then((response) => {
          console.log(response);
          this.playersfound = response.data;
        }).catch(error => console.log(error));
    },
  },
};
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css?family=Sen&display=swap');
@import url('https://fonts.googleapis.com/css?family=Roboto&display=swap');
#players {
    width: 90%;
    margin: auto;
    text-align: left;
}
#players-table {
    width: 100%;
    margin: auto;
    text-align: center;
    border: 1px solid #000;
}
h4{
    text-align: left;
}
th {
    font-family: 'Roboto' sans-serif;
    font-family: 22px;
    padding: 5px;
    border-bottom: 1px solid #000;
}
td {
    font-family: 'Sen', sans-serif;
}
</style>
