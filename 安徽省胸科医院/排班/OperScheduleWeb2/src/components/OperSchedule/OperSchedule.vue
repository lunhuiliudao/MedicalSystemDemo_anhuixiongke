<template>
  <div>
    <OsLeftMenu></OsLeftMenu>
    <OsMain></OsMain>
  </div>
</template>

<script>
import OsLeftMenu from './OsLeftMenu/OsLeftMenu.vue'
import OsMain from './OsMain/OsMain.vue'
export default {
  name: 'OperSchedule',
  components: { OsLeftMenu, OsMain }
}
</script>
