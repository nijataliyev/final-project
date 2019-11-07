<template>
  <v-toolbar dark app :color="$root.themeColor">
    <v-toolbar-title>
      <v-toolbar-side-icon @click="toggleNavigationBar"></v-toolbar-side-icon>
    </v-toolbar-title>
    <v-spacer></v-spacer>

    <v-dialog v-model="dialogSettings" width="700">
      <v-card>
        <v-card-title class="headline" primary-title>Settings</v-card-title>

        <v-card-text>
          Choose theme color ?
          <swatches
            v-model="$root.themeColor"
            inline
            colors="material-dark"
            :exceptions="['#FFFFFF']"
            shapes="circles"
            show-border
          ></swatches>
        </v-card-text>

        <v-card-text>
          Set Up System User
          <v-form>
            <v-container>
              <v-layout row wrap>
                <v-flex xs12 xs6 md11>
                  <v-text-field v-model="userEmail" label="User Email" hint="Set user email" />
                </v-flex>

                <v-flex xs12 xs6 md1 />

                <v-flex xs12 sm6 md11>
                  <v-text-field
                    v-model="password"
                    :append-icon="showPassword ? 'visibility_off' : 'visibility'"
                    :type="showPassword ? 'text' : 'password'"
                    label="New Password"
                    hint="Please choose a complex one.."
                    :error="error"
                    @click:append="showPassword = !showPassword"
                  />
                </v-flex>

                <v-flex xs12 sm6 md1 />

                <v-flex xs12 sm6 md11>
                  <v-text-field
                    v-model="passwordConfirm"
                    :append-icon="showPasswordConfirm ? 'visibility_off' : 'visibility'"
                    :type="showPasswordConfirm ? 'text' : 'password'"
                    label="Confirm New Password"
                    hint="and confirm it."
                    :error="error"
                    @click:append="showPasswordConfirm = !showPasswordConfirm"
                  />
                </v-flex>

                <v-flex xs12 sm6 md1 />

                <v-flex xs12 xs6 md11>
                  <v-switch
                    label="Email Notification"
                    color="success"
                    v-model="switchEmailNotification"
                  />
                </v-flex>

                <v-flex xs12 xs6 md1 />
              </v-layout>
            </v-container>
          </v-form>
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" flat @click="setUpSettings">Save Changes</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-snackbar v-model="showResult" :timeout="2000" top>{{ result }}</v-snackbar>

    <v-menu offset-y origin="center center" :nudge-bottom="10" transition="scale-transition">
      <v-btn icon large flat slot="activator" :ripple="false">
        <v-avatar size="42px">
          <img src="static/beardMan.jpg" />
        </v-avatar>
      </v-btn>
      <v-list>
        <v-list-tile
          v-for="(item,index) in items"
          :key="index"
          :to="!item.href ? { name: item.name } : null"
          :href="item.href"
          ripple="ripple"
          :disabled="item.disabled"
          :target="item.target"
          @click="item.click"
        >
          <v-list-tile-action v-if="item.icon">
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>{{ item.title }}</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-menu>
  </v-toolbar>
</template>
<script>
export default {
  data() {
    return {
      rating: null,
      dialog: false,
      dialogSettings: false,
      switchEmailNotification: true,
      showPassword: null,
      showPasswordConfirm: null,
      userEmail: null,
      password: null,
      passwordConfirm: null,
      error: false,
      showResult: false,
      result: "",
      items: [
        {
          icon: "account_circle",
          href: "#",
          title: "Profile",
          click: e => {}
        },
        {
          icon: "settings",
          href: "#",
          title: "Settings",
          click: () => {
            const vm = this;

            vm.dialogSettings = true;
          }
        },
        {
          icon: "exit_to_app",
          href: "#",
          title: "Log Out",
          click: () => {
            this.$store.dispatch("destroyToken").then(response => {
              console.log(response)
                this.$router.push({ name: "Login" });

            });
          }
        }
      ],
      notifications: [
        {
          title: "New mail from Adam Joe",
          color: "light-blue",
          icon: "email",
          actionAt: "12 min ago",
          isActive: true,
          onClick: () => {
            const vm = this;

            vm.$router.push({ name: "Mailbox" });
          }
        },
        {
          title: "Scheculed meeting",
          color: "red",
          icon: "calendar_today",
          actionAt: "46 min ago",
          isActive: true,
          onClick: () => {
            const vm = this;

            vm.$router.push({ name: "Calendar" });
          }
        },
        {
          title: "New mail from Github",
          color: "light-blue",
          icon: "email",
          isActive: true,
          timeLabel: "2 hour ago",
          onClick: () => {
            const vm = this;

            vm.$router.push({ name: "Mailbox" });
          }
        }
      ]
    };
  },

  methods: {
    toggleNavigationBar() {
      const vm = this;

      vm.$emit("toggleNavigationBar");
    },

    setUpSettings() {
      const vm = this;

      if (
        vm.userEmail === null ||
        vm.password === null ||
        vm.passwordConfirm === null
      ) {
        vm.result = "Email and Password can't be null.";
        vm.showResult = true;

        return;
      }

      if (vm.password !== vm.passwordConfirm) {
        vm.error = true;
        vm.result = "Passwords does not match the confirm password.";
        vm.showResult = true;

        return;
      }

      vm.$root.userEmail = vm.userEmail;
      vm.$root.userPassword = vm.password;

      vm.result = "Email and password changed succesfully.";
      vm.showResult = true;

      vm.dialogSettings = false;
    }
  }
};
</script>
