<template>
  <div class="players">
    <h1>This is the players page</h1>
    <PlayersList />
  </div>
</template>

<script>
// @ is an alias to /src
// eslint-disable-next-line import/no-unresolved
import PlayersList from '@/components/PlayersList.vue';

export default {
  name: 'players',
  components: {
    PlayersList,
  },
};
</script>
