import { expect } from 'chai';
import { shallowMount } from '@vue/test-utils';
// eslint-disable-next-line import/extensions
// eslint-disable-next-line import/no-unresolved
import PlayersList from '@/components/PlayersList.vue';

describe('PlayersList.vue', () => {
  it('renders list of players', () => {
    const expectedText = 'PlayersUserNameEmailDateJoined';
    const wrapper = shallowMount(PlayersList);
    expect(wrapper.text()).to.include(expectedText);
  });
});
