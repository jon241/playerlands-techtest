<template>
    <div id="players">
        <h2 id = "players-heading">Players</h2>
        <table id = "players-table">
            <tr>
                <th>UserName</th>
                <th>Email</th>
                <th>DateJoined</th>
            </tr>
            <tr v-for = "player in playersfound" :key = "player.dateJoined">
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
// import playersAPI from '@/services/api/Players.js';
import axios from 'axios';

// axios.defaults.baseUrl = 'http://localhost:5000/api';

export default {
  name: 'PlayersList',
  data() {
    return {
      playersfound: [],
    };
  },
  created() {
    // axios.get('/players')
    //   .then((response) => {
    //     console.log(response);
    //     this.players = response.data;
    //   }).catch(error => console.log(error));
    this.getPlayers();
  //   playersAPI.getPlayers()
  //     .then((players) => {
  //       // console.log(players);
  //       this.players = players;
  //     })
  //     .catch(error => console.log(error));
  },
  methods: {
    getPlayers() {
      // console.log(axios.defaults.baseURL);
      axios.get('http://localhost:5000/api/players')
        .then((response) => {
          // why does this have no players when the API itself works???
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
    text-align: center;
}
#players-heading {
    font-family: 'Sen', sans-serif;
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
